using System;

namespace MetaFac.Mutability.Tests
{
#if NET5_0_OR_GREATER
    public record SampleRecord : ISample, IFreezable
    {
        public int Field1 { get; init; }
        public void Freeze() { }
        public bool IsFreezable() => false;
        public bool IsFrozen() => true;
        public bool TryFreeze() => false;
        public SampleRecord() { }
        public SampleRecord(ISample source)
        {
            Field1 = source.Field1;
        }
    }
#endif
}