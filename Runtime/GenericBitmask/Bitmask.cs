using System;
using Dre0Dru.Collections;

namespace Dre0Dru.GenericBitmask
{
    public struct Bitmask<T> : IEquatable<Bitmask<T>>
        where T: class
    {
        private readonly BitCounter32<T> _collection;

        private uint _mask;

        public uint Mask => _mask;

        public Bitmask(BitCounter32<T> collection)
        {
            _collection = collection;
            _mask = 0;
        }

        public Bitmask<T> With(T tag)
        {
            _mask |= _collection.GetBit(tag);

            return this;
        }

        public bool Matches(BitmaskFilter<T> filter) =>
            filter.Matches(this);

        public bool Equals(Bitmask<T> other)
        {
            return _mask == other._mask;
        }

        public override bool Equals(object obj)
        {
            return obj is Bitmask<T> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (int)_mask;
        }
    }
}