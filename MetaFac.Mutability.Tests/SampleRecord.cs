using System;

namespace MetaFac.Mutability.Tests
{
    public record SampleRecord : ISample, IFreezable, ICopyFrom<ISample>
    {
        public int Field1 { get; init; }
        public void Freeze() { }
        public bool IsFrozen() => true;
        public void CopyFrom(ISample source)
        {
            throw new InvalidOperationException();
        }
        public SampleRecord() { }
        public SampleRecord(ISample source)
        {
            Field1 = source.Field1;
        }
    }
}