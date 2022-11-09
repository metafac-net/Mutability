using System;
using System.Runtime.CompilerServices;

namespace MetaFac.Mutability.Tests
{
    public abstract class BaseFreezable : IFreezable
    {
        private volatile bool _immutable = false;
        public void Freeze() { _immutable = true; }
        public bool IsFrozen() => _immutable;

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void ThrowInvalidOperation()
        {
            throw new InvalidOperationException();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected ref T EnsureMutable<T>(ref T value)
        {
            if (_immutable) ThrowInvalidOperation();
            return ref value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void EnsureMutable()
        {
            if (_immutable) ThrowInvalidOperation();
        }
    }
}