using System;

namespace MetaFac.Mutability.Tests
{
#if NET5_0_OR_GREATER
    public record SampleRecord : RecordBase, ISample
    {
        public int Field1 { get; init; }
        public SampleRecord() { }
        public SampleRecord(ISample source) 
        {
            Field1 = source.Field1;
        }
    }
#endif
}