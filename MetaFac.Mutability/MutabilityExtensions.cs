using System;
using System.Runtime.CompilerServices;

namespace MetaFac.Mutability
{
    public static class MutabilityExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Frozen<T>(this T original)
            where T : class, IFreezable
        {
            original.Freeze();
            return original;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Unfrozen<T>(this T? source)
            where T : class, IFreezable, ICopyFrom<T>, new()
        {
            if (source is null)
                return new T();

            if (!source.IsFrozen())
                return source;

            T clone = new();
            clone.CopyFrom(source);
            return clone;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TOut Unfrozen<TOut, TInp>(this TInp? source)
            where TOut : class, IFreezable, ICopyFrom<TInp>, new()
            where TInp : class
        {
            if (source is null)
                return new TOut();

            if (source is TOut sibling && !sibling.IsFrozen())
                return sibling;

            TOut clone = new();
            clone.CopyFrom(source);
            return clone;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T With<T>(this T? self, Action<T> action, bool refreeze = false)
            where T : class, IFreezable, ICopyFrom<T>, new()
        {
            T mutable = self.Unfrozen();
            action(mutable);
            return refreeze ? mutable.Frozen() : mutable;
        }
    }

}
