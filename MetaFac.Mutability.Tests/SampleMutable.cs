using System;

namespace MetaFac.Mutability.Tests
{
    public class SampleMutable : ISample, IFreezable, ICopyFrom<ISample>
    {
        public int Field1 { get; set; }
        public void Freeze() => throw new InvalidOperationException();
        public bool IsFrozen() => false;
        public void CopyFrom(ISample source)
        {
            Field1 = source.Field1;
        }
    }
}