using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Fmacias.TplQueue
{
    public enum NodeExecStatus { Pending, Runnable, Running, Succeeded, Failed, Canceled }

    /// <summary>Immutable-ish snapshot of a node's execution state.</summary>
    public sealed class NodeState
    {
        public NodeExecStatus Status { get; private set; }
        public int Attempts { get; private set; }
        public DateTime? NextVisibleUtc { get; private set; }
        public string? LastError { get; private set; }

        public NodeState(NodeExecStatus status, int attempts, DateTime? nextVisibleUtc, string? lastError)
        {
            if (attempts < 0) throw new ArgumentOutOfRangeException(nameof(attempts));
            Status = status;
            Attempts = attempts;
            NextVisibleUtc = nextVisibleUtc;
            LastError = lastError;
        }

        public NodeState With(
            NodeExecStatus? status = null,
            int? attempts = null,
            DateTime? nextVisibleUtc = null,
            string? lastError = null)
            => new NodeState(status ?? Status, attempts ?? Attempts, nextVisibleUtc ?? NextVisibleUtc, lastError ?? LastError);
    }

    /// <summary>Aggregated execution state for a root.</summary>
    public sealed class RootExecutionState
    {
        private readonly Dictionary<Guid, NodeState> _nodes;
        public IReadOnlyDictionary<Guid, NodeState> Nodes => new ReadOnlyDictionary<Guid, NodeState>(_nodes);

        public RootExecutionState(Dictionary<Guid, NodeState> nodes)
        {
            _nodes = nodes ?? throw new ArgumentNullException(nameof(nodes));
        }

        public RootExecutionState Set(Guid nodeId, NodeState state)
        {
            if (!_nodes.ContainsKey(nodeId))
            {
                var clone = new Dictionary<Guid, NodeState>(_nodes) { [nodeId] = state };
                return new RootExecutionState(clone);
            }
            else
            {
                var clone = new Dictionary<Guid, NodeState>(_nodes);
                clone[nodeId] = state;
                return new RootExecutionState(clone);
            }
        }
    }
}
