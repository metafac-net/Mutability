using System.Runtime.CompilerServices;
using System.Threading;
using System;

namespace MetaFac.Mutability
{
    // Kind         IsFreezable     IsFrozen
    // Mutable      false           false
    // Immutable    false           true
    // Freezable    true            false/true

    /// <summary>
    /// Represents a freezable type i.e. one that can change state from mutable to immutable.
    /// </summary>
    public interface IFreezable
    {
        /// <summary>
        /// Indicates if this type is freezable i.e. one that can change state from mutable to immutable.
        /// </summary>
        /// <returns>true if the type is freezable; otherwise false</returns>
        bool IsFreezable();

        /// <summary>
        /// Returns false if mutable, or true if immutable. When immutable,
        /// modification attempts will throw InvalidOperationException.
        /// </summary>
        /// <returns></returns>
        bool IsFrozen();

        /// <summary>
        /// Makes this object, including any contained objects, immutable.
        /// Always mutable types will throw InvalidOperationException. 
        /// Always immutable types will do nothing.
        /// </summary>
        void Freeze();

        /// <summary>
        /// Makes this object, including any contained objects, immutable.
        /// Returns false if already immutable.
        /// Returns true if previously mutable.
        /// Always mutable types will throw InvalidOperationException.
        /// Always immutable types will do nothing.
        /// </summary>
        bool TryFreeze();
    }
}