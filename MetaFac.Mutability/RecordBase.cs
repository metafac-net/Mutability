namespace MetaFac.Mutability
{
    public record RecordBase : IFreezable
    {
        public bool IsFreezable() => false;
        public bool IsFrozen() => true;
        public void Freeze() { }
        public bool TryFreeze() => false;
        public RecordBase() { }
        public RecordBase(RecordBase source) { }
    }

}