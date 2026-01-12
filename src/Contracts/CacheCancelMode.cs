// Abstractions/Contracts/CacheCancelMode.cs
namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public enum CacheCancelMode
    {
        /// <summary>Remove the item from the cache on cancel.</summary>
        Remove,
        /// <summary>Keep the item in the cache but mark as Canceled (can be listed/requeued later).</summary>
        MarkCanceled
    }
}
