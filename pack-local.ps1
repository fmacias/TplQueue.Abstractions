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

# Pick a packing target: prefer *.Pack.sln, fall back to first *.sln, else the repo root.
# Example: returns C:\repo\TplQueue.Abstractions\Abstractions.Pack.sln if it exists.
function Get-PackTarget {
  param([string]$RepoRoot)

  $packSolution = Get-ChildItem -Path $RepoRoot -Filter '*.Pack.sln' | Select-Object -First 1
  if (-not $packSolution) {
    $packSolution = Get-ChildItem -Path $RepoRoot -Filter '*.sln' | Select-Object -First 1
  }

  if ($packSolution) {
    return $packSolution.FullName
  }

  return $RepoRoot
}

# Run dotnet pack to generate nupkg files into the local NuGet folder.
# Example: Pack-Local -PackTarget C:\repo\TplQueue.Abstractions\abstractions.sln -NugetRoot C:\repo\TplQueue.NugetLocal
function Pack-Local {
  param(
    [string]$PackTarget,
    [string]$NugetRoot
  )

  Write-Host "Packing $PackTarget to $NugetRoot..."
  Invoke-Dotnet -DotnetArgs @('pack', $PackTarget, '-c', 'Release', '-o', $NugetRoot, '-p:SkipPackLocal=true')
  Write-Host 'Local NuGet packages created successfully.'
}

# Orchestrate the steps needed to build local packages in a predictable order.
# Example: running the script in TplQueue.Abstractions will pack into ..\TplQueue.NugetLocal.
function Main {
  $repoRoot = Get-RepoRoot
  $nugetRoot = Ensure-NugetLocal -RepoRoot $repoRoot
  Ensure-NugetSource -SourceName 'TplQueue.NugetLocal' -SourcePath $nugetRoot

  $packTarget = Get-PackTarget -RepoRoot $repoRoot
  Pack-Local -PackTarget $packTarget -NugetRoot $nugetRoot
}

try {
  Main
} catch {
  Write-Error $_.Exception.Message
  exit 1
}
