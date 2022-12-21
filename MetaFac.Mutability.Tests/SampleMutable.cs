using System;

namespace MetaFac.Mutability.Tests
{
    public class SampleMutable : ISample, IFreezable, ICopyFrom<ISample>
    {
        public int Field1 { get; set; }
        public bool IsFreezable() => false;
        public void Freeze() { }
        public bool TryFreeze() => false;
        public bool IsFrozen() => false;
        public void CopyFrom(ISample source)
        {
            Field1 = source.Field1;
        }
    }
}