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
        public void IApi_ExposesOnlySystemTextSerializerFactoryMethod()
        {
            var methodNames = typeof(IApi)
                .GetMethods()
                .Where(method => method.ReturnType == typeof(ISystemTextJsonSerializerFactory))
                .Select(method => method.Name)
                .ToArray();

            Assert.That(methodNames, Does.Contain(nameof(IApi.SystemTextSerializerFactory)));
            Assert.That(methodNames, Does.Not.Contain("SystemTexSerializerFactory"));
        }

        [Test]
        public void IJobNodeRecord_UsesSerializedPayloadNaming()
        {
            Assert.Multiple(() =>
            {
                Assert.That(typeof(IJobNodeRecord).GetProperty(nameof(IJobNodeRecord.SerializedPayload)), Is.Not.Null);
                Assert.That(typeof(IJobNodeRecord).GetMethod(nameof(IJobNodeRecord.UpdateSerializedPayload)), Is.Not.Null);
                Assert.That(typeof(IJobNodeRecord).GetProperty("PayloadJson"), Is.Null);
                Assert.That(typeof(IJobNodeRecord).GetMethod("UpdatePayloadJson"), Is.Null);
            });
        }

        [Test]
        public void IPayload_ExposesHandlerKeyAsString()
        {
            var property = typeof(IPayload).GetProperty(nameof(IPayload.HandlerKey));

            Assert.Multiple(() =>
            {
                Assert.That(property, Is.Not.Null);
                Assert.That(property!.PropertyType, Is.EqualTo(typeof(string)));
                Assert.That(property.CanRead, Is.True);
                Assert.That(property.CanWrite, Is.False);
            });
        }

        [TestCase(typeof(IDataJob), typeof(IJob[]), typeof(IDataJob))]
        [TestCase(typeof(IDataJobRoot), typeof(IJobNode[]), typeof(IDataJobRoot))]
        public void DataJobContracts_ExposeTypedAfter(
            Type contractType,
            Type dependencyType,
            Type returnType)
        {
            var method = contractType
                .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Single(candidate => candidate.Name == nameof(IJob.After));

            Assert.Multiple(() =>
            {
                Assert.That(method.ReturnType, Is.EqualTo(returnType));
                Assert.That(method.GetParameters(), Has.Length.EqualTo(1));
                Assert.That(method.GetParameters()[0].ParameterType, Is.EqualTo(dependencyType));
                Assert.That(
                    method.GetParameters()[0].GetCustomAttribute<ParamArrayAttribute>(),
                    Is.Not.Null);
            });
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
