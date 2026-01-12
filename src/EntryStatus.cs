namespace Fmaciasruano.TplQueue.Abstractions
{
    public enum EntryStatus {
        Pending,
        Leased, 
        Acknownledged, 
        Failed, 
        Canceled
    }
}
