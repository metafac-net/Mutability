using System;

namespace MetaFac.Mutability
{
    public class MutableBase : IFreezable, ICopyFrom<MutableBase>, IEquatable<MutableBase>
    {
        public bool IsFreezable() => false;
        public bool IsFrozen() => false;
        public void Freeze() { }
        public bool TryFreeze() => false;
        public MutableBase() { }
        public MutableBase(MutableBase source) { }
        public void CopyFrom(MutableBase source) { }
        public override int GetHashCode() => 0;
        public override bool Equals(object? obj) => obj is MutableBase other && Equals(other);
        public bool Equals(MutableBase? other) => other is not null;
    }

}