using System;
using System.Linq;
using System.Reflection;
using Fmacias.TplQueue.Contracts;
using NUnit.Framework;

namespace Fmacias.TplQueue.Abstractions.UnitTests.Contracts
{
    [TestFixture]
    public class ContractCompatibilityTests
    {
        [Test]
        public void IJobEvent_JobInfo_RemainsMetadataFirstIJobInfo()
        {
            var property = typeof(IJobEvent).GetProperty(nameof(IJobEvent.JobInfo));

            Assert.That(property, Is.Not.Null);
            Assert.That(property!.PropertyType, Is.EqualTo(typeof(IJobInfo)));
        }

        [Test]
        public void IApi_ExposesPreferredAndCompatibilitySerializerFactoryMethods()
        {
            var methodNames = typeof(IApi)
                .GetMethods()
                .Where(method => method.ReturnType == typeof(ISystemTextJsonSerializerFactory))
                .Select(method => method.Name)
                .ToArray();

            Assert.That(methodNames, Does.Contain(nameof(IApi.SystemTextSerializerFactory)));
            Assert.That(methodNames, Does.Contain(nameof(IApi.SystemTexSerializerFactory)));
        }

        [Test]
        public void IJobInfoDto_IsMarkedAsObsoleteCompatibilityAlias()
        {
#pragma warning disable CS0618
            var obsoleteAttribute = typeof(IJobInfoDto).GetCustomAttribute<ObsoleteAttribute>();
#pragma warning restore CS0618

            Assert.That(obsoleteAttribute, Is.Not.Null);
            Assert.That(obsoleteAttribute!.IsError, Is.False);
            Assert.That(obsoleteAttribute.Message, Does.Contain(nameof(IJobInfo)));
        }
    }
}
