param(
  [string]$Version
)

$ErrorActionPreference = 'Stop'

# Run dotnet with a known argument list and stop on non-zero exit.
# Example: Invoke-Dotnet -DotnetArgs @('pack','My.sln','-c','Release')
function Invoke-Dotnet {
  param([string[]]$DotnetArgs)

  & dotnet @DotnetArgs
  if ($LASTEXITCODE -ne 0) {
    throw "dotnet $($DotnetArgs -join ' ') failed with exit code $LASTEXITCODE."
  }
}

function Get-PackVersionProperties {
  param([string]$Version)

  if ([string]::IsNullOrWhiteSpace($Version)) {
    return @()
  }

  return @(
    "-p:Version=$Version",
    "-p:PackageVersion=$Version"
  )
}

# Return the folder that contains this script.
# Example: if this script is in C:\repo\TplQueue.Abstractions\pack-local.ps1, returns C:\repo\TplQueue.Abstractions.
function Get-RepoRoot {
  if ($PSScriptRoot) {
    return $PSScriptRoot
  }

  if ($PSCommandPath) {
    return Split-Path -Parent $PSCommandPath
  }

  throw 'Unable to resolve the script directory.'
}

# Ensure the local NuGet folder exists and return its absolute path.
# Example: for repo root C:\repo\TplQueue.Abstractions, ensures C:\repo\TplQueue.NugetLocal and returns that path.
function Ensure-NugetLocal {
  param([string]$RepoRoot)

  $nugetRoot = Join-Path $RepoRoot '..\TplQueue.NugetLocal'
  if (-not (Test-Path $nugetRoot)) {
    New-Item -ItemType Directory -Path $nugetRoot -Force | Out-Null
  }

  return (Resolve-Path $nugetRoot).Path
}

# Register the local NuGet folder as a source if it is missing.
# Example: Ensure-NugetSource -SourceName 'TplQueue.NugetLocal' -SourcePath C:\repo\TplQueue.NugetLocal
function Ensure-NugetSource {
  param(
    [string]$SourceName,
    [string]$SourcePath
  )

  $sources = (& dotnet nuget list source) | Out-String
  if ($LASTEXITCODE -ne 0) {
    throw 'dotnet nuget list source failed.'
  }

  if ($sources -notmatch [regex]::Escape($SourcePath)) {
    Invoke-Dotnet -DotnetArgs @('nuget', 'add', 'source', $SourcePath, '-n', $SourceName)
  }
}

# Resolve NuGet global-packages folder dynamically.
function Get-GlobalPackagesPath {
  $output = (& dotnet nuget locals global-packages -l) | Out-String
  if ($LASTEXITCODE -ne 0) {
    throw 'dotnet nuget locals global-packages failed.'
  }

  $match = [regex]::Match($output, ':\s*(.+)$')
  if ($match.Success) {
    return $match.Groups[1].Value.Trim()
  }

  if ($env:NUGET_PACKAGES) {
    return $env:NUGET_PACKAGES
  }

  return (Join-Path $env:USERPROFILE '.nuget\\packages')
}

# Clear stale local cache entries for Fmacias packages before packing.
function Clear-LocalNugetCache {
  $packagesRoot = Get-GlobalPackagesPath
  if (-not (Test-Path $packagesRoot)) {
    return
  }

  Get-ChildItem -Path $packagesRoot -Directory |
    Where-Object { $_.Name -like 'fmacias.tplqueue*' -or $_.Name -like 'fmaciasruano.tplqueue*' } |
    Remove-Item -Recurse -Force
}

# Run dotnet pack to generate nupkg files into the local NuGet folder.
# Example: Pack-Local -PackTarget C:\repo\TplQueue.Abstractions\abstractions.sln -NugetRoot C:\repo\TplQueue.NugetLocal
function Pack-Local {
  param(
    [string]$PackTarget,
    [string]$NugetRoot,
    [string]$Version
  )

  Write-Host "Packing $PackTarget to $NugetRoot..."
  $dotnetArgs = @(
    'pack',
    $PackTarget,
    '-c', 'Release',
    '-o', $NugetRoot,
    '-p:SkipPackLocal=true',
    '-p:RestoreNoCache=true',
    '-p:RestoreForce=true'
  ) + (Get-PackVersionProperties -Version $Version)

  Invoke-Dotnet -DotnetArgs $dotnetArgs
  Write-Host 'Local NuGet packages created successfully.'
}

# Orchestrate the steps needed to build local packages in a predictable order.
# Example: running the script in TplQueue.Abstractions will pack into ..\TplQueue.NugetLocal.
function Main {
  $repoRoot = Get-RepoRoot
  if (-not [string]::IsNullOrWhiteSpace($Version)) {
    Write-Host "Coordinated package version: $Version"
  }

  $nugetRoot = Ensure-NugetLocal -RepoRoot $repoRoot
  Ensure-NugetSource -SourceName 'TplQueue.NugetLocal' -SourcePath $nugetRoot
  Clear-LocalNugetCache
  Pack-Local -PackTarget $repoRoot -NugetRoot $nugetRoot -Version $Version
}

try {
  Main
} catch {
  Write-Error $_.Exception.Message
  exit 1
}
