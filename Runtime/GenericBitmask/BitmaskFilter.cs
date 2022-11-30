using System;
using Dre0Dru.Collections;

namespace Dre0Dru.GenericBitmask
{
    public struct BitmaskFilter<T> : IEquatable<BitmaskFilter<T>>
        where T: class
    {
        private readonly BitCounter32<T> _bitCounter;

        private uint _includeMask;
        private uint _excludeMask;

        public BitmaskFilter(BitCounter32<T> bitCounter)
        {
            _bitCounter = bitCounter;
            _includeMask = 0;
            _excludeMask = 0;
        }

        public BitmaskFilter<T> Include(T tag)
        {
            _includeMask |= _bitCounter.GetBit(tag);

            return this;
        }

        public BitmaskFilter<T> Exclude(T tag)
        {
            _excludeMask |= _bitCounter.GetBit(tag);

            return this;
        }
        
        public bool Matches(Bitmask<T> bitmask) =>
            (bitmask.Mask & _includeMask) == _includeMask &&
            (bitmask.Mask & _excludeMask) == 0;

        public bool Equals(BitmaskFilter<T> other)
        {
            return _includeMask == other._includeMask && _excludeMask == other._excludeMask;
        }

        public override bool Equals(object obj)
        {
            return obj is BitmaskFilter<T> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_includeMask, _excludeMask);
        }
    }
}