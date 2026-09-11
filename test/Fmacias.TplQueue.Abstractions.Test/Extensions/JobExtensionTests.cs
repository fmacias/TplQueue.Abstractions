using System;
using System.Linq;
using System.Reflection;
using Fmacias.TplQueue.Contracts;
using Fmacias.TplQueue.Extensions;
using NUnit.Framework;

namespace Fmacias.TplQueue.Abstractions.UnitTests.Extensions
{
    [TestFixture]
    public class JobExtensionTests
    {
        [Test]
        public void Then_WithDataJobs_AddsDependencyAndReturnsNextDataJob()
        {
            var previous = CreateProxy<IDataJob>(out _);
            var next = CreateProxy<IDataJob>(out var nextProxy);
            var afterResult = CreateProxy<IDataJob>(out _);
            nextProxy.AfterResult = afterResult;

            var result = previous.Then(next);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.SameAs(afterResult));
                Assert.That(nextProxy.Dependencies, Has.Length.EqualTo(1));
                Assert.That(nextProxy.Dependencies[0], Is.SameAs(previous));
            });
        }

        [Test]
        public void Then_WithDataJobRoot_AddsDependencyAndReturnsNextDataJobRoot()
        {
            var previous = CreateProxy<IDataJobNode>(out _);
            var next = CreateProxy<IDataJobRoot>(out var nextProxy);
            var afterResult = CreateProxy<IDataJobRoot>(out _);
            nextProxy.AfterResult = afterResult;

            var result = previous.Then(next);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.SameAs(afterResult));
                Assert.That(nextProxy.Dependencies, Has.Length.EqualTo(1));
                Assert.That(nextProxy.Dependencies[0], Is.SameAs(previous));
            });
        }

        [Test]
        public void Then_WithDataJobs_ThrowsForNullArgument()
        {
            var job = CreateProxy<IDataJob>(out _);

            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentNullException>(() => JobExtension.Then((IDataJob)null, job));
                Assert.Throws<ArgumentNullException>(() => JobExtension.Then(job, (IDataJob)null));
            });
        }

        [Test]
        public void Then_WithDataJobRoot_ThrowsForNullArgument()
        {
            var node = CreateProxy<IDataJobNode>(out _);
            var root = CreateProxy<IDataJobRoot>(out _);

            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentNullException>(() => JobExtension.Then((IDataJobNode)null, root));
                Assert.Throws<ArgumentNullException>(() => JobExtension.Then(node, (IDataJobRoot)null));
            });
        }

        private static T CreateProxy<T>(out RecordingProxy proxy)
            where T : class
        {
            var instance = DispatchProxy.Create<T, RecordingProxy>();
            proxy = (RecordingProxy)(object)instance;
            return instance;
        }

        public class RecordingProxy : DispatchProxy
        {
            public object AfterResult { get; set; }
            public object[] Dependencies { get; private set; } = Array.Empty<object>();

            protected override object Invoke(MethodInfo targetMethod, object[] args)
            {
                if (targetMethod.Name == nameof(IJob.After))
                {
                    Dependencies = ((Array)args[0]).Cast<object>().ToArray();
                    return AfterResult;
                }

                throw new InvalidOperationException($"Unexpected member invocation: {targetMethod.Name}.");
            }
        }
    }
}
