namespace Life.Core.Events
{
    public abstract class HpChangeEvent : Event
    {
        public int HpChange { get; set; }
    }
}
