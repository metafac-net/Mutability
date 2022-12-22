using System;

namespace MetaFac.Mutability
{
    public class ImmutableBase : IFreezable, IEquatable<ImmutableBase>
    {
        public bool IsFreezable() => false;
        public bool IsFrozen() => true;
        public void Freeze() { }
        public bool TryFreeze() => false;
        public ImmutableBase() { }
        public ImmutableBase(ImmutableBase source) { }
        public override int GetHashCode() => 0;
        public override bool Equals(object? obj) => obj is ImmutableBase other && Equals(other);
        public bool Equals(ImmutableBase? other) => other is not null;
    }

}