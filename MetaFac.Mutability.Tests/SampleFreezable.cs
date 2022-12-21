using System;

namespace MetaFac.Mutability.Tests
{
    public class SampleFreezable : FreezableBase, ISample, ICopyFrom<SampleFreezable>, ICopyFrom<ISample>, IEquatable<SampleFreezable>
    {
        private int field1;
        public int Field1 { get => field1; set => field1 = CheckNotFrozen(ref value); }
        public static SampleFreezable Create(Action<SampleFreezable> initMethod)
        {
            SampleFreezable freezable = new();
            try
            {
                initMethod(freezable);
            }
            finally
            {
                freezable.Freeze();
            }
            return freezable;
        }
        protected override void OnFreeze()
        {
        }
        public void CopyFrom(ISample source)
        {
            ThrowIfFrozen();
            Field1 = source.Field1;
        }
        public void CopyFrom(SampleFreezable source)
        {
            base.CopyFrom(source);
            field1 = source.field1;
        }

        public bool Equals(SampleFreezable? other)
        {
            if (other is null) return false;
            if (other.field1 != field1) return false;
            return true;
        }

        public override bool Equals(object? obj)
        {
            return obj is SampleFreezable other && Equals(other);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(field1);
        }
    }
}