namespace Fmacias.TplQueue
{
    public enum EntryStatus {
        Pending,
        Leased, 
        Acknownledged, 
        Failed, 
        Canceled
    }
}
