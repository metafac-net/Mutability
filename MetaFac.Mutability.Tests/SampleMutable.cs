using System;

namespace MetaFac.Mutability.Tests
{
    public class SampleMutable : MutableBase, ISample, ICopyFrom<ISample>
    {
        public int Field1 { get; set; }
        public void CopyFrom(ISample source)
        {
            Field1 = source.Field1;
        }
    }
}