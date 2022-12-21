using System.Runtime.CompilerServices;
using System;

namespace MetaFac.Mutability
{
    public abstract class FreezableBase : IFreezable, ICopyFrom<FreezableBase>, IEquatable<FreezableBase>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        protected static void ThrowFrozen([CallerMemberName] string? method = null)
        {
            throw new InvalidOperationException($"Cannot call '{method}' when frozen");
        }

        /// <summary>
        /// Throws InvalidOperationException if immutable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected ref T CheckNotFrozen<T>(ref T value, [CallerMemberName] string? method = null)
        {
            if (_frozen) ThrowFrozen(method);
            return ref value;
        }

        /// <summary>
        /// Throws InvalidOperationException if immutable.
        /// </summary>
        /// <param name="method"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void ThrowIfFrozen([CallerMemberName] string? method = null)
        {
            if (IsFrozen()) ThrowFrozen(method);
        }

        protected volatile bool _frozen = false;

        public bool IsFrozen() => _frozen;
        public bool IsFreezable() => true;

        public FreezableBase() { }

        public FreezableBase(FreezableBase source) { }

        public void CopyFrom(FreezableBase source)
        {
            ThrowIfFrozen();
        }

        protected abstract void OnFreeze();

        public void Freeze()
        {
            if (_frozen) return;
            OnFreeze();
            _frozen = true;
        }

        public bool TryFreeze()
        {
            if (_frozen) return false;
            OnFreeze();
            _frozen = true;
            return _frozen;
        }

        public override int GetHashCode() => 0;
        public override bool Equals(object? obj) => obj is FreezableBase other && Equals(other);
        public bool Equals(FreezableBase? other) => other is not null;
    }

}