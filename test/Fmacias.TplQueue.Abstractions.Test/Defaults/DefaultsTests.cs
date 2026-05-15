using System;
using System.Threading;
using System.Threading.Tasks;
using Fmacias.TplQueue.Defaults;
using NUnit.Framework;

namespace Fmacias.TplQueue.Abstractions.UnitTests.Defaults
{
    [TestFixture]
    public class DefaultsTests
    {
        [Test]
        public async Task NoRetryPolicy_ExecuteAsync_RunsActionOnce()
        {
            var sut = NoRetryPolicy.Create();
            var invocationCount = 0;

            var result = await sut.ExecuteAsync(
                cancellationToken =>
                {
                    invocationCount++;
                    return Task.FromResult(invocationCount);
                },
                CancellationToken.None);

            Assert.That(result, Is.EqualTo(1));
            Assert.That(invocationCount, Is.EqualTo(1));
            Assert.That(sut.RetryCount, Is.Zero);
        }

        [Test]
        public void NoRetryPolicy_ExecuteAsync_ThrowsForNullAction()
        {
            var sut = NoRetryPolicy.Create();

            Assert.ThrowsAsync<ArgumentNullException>(
                async () => await sut.ExecuteAsync<int>(null, CancellationToken.None));
        }

        [Test]
        public void RetryPolicyOptions_Create_AssignsImmutableValues()
        {
            var descriptor = RetryPolicyOptions.Create(125, 3, 2.5d);

            Assert.Multiple(() =>
            {
                Assert.That(descriptor.BaseDelayMs, Is.EqualTo(125));
                Assert.That(descriptor.MaxRetries, Is.EqualTo(3));
                Assert.That(descriptor.Factor, Is.EqualTo(2.5d));
            });
        }

        [Test]
        public void QOptions_Ctor_ThrowsWhenRetryPolicyIsBlank()
        {
            Assert.Throws<ArgumentException>(
                () => new QOptions(Guid.NewGuid(), 1, " "));
        }

        [Test]
        public void TypeDeserializer_TryResolveType_ResolvesLoadedTypeByFullName()
        {
            var resolved = TypeDeserializer.TryResolveType(typeof(QOptions).FullName, out var type);

            Assert.Multiple(() =>
            {
                Assert.That(resolved, Is.True);
                Assert.That(type, Is.EqualTo(typeof(QOptions)));
            });
        }
    }
}
