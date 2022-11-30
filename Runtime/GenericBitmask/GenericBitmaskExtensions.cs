using System.Collections.Generic;

namespace Dre0Dru.GenericBitmask
{
    public static class GenericBitmaskExtensions
    {
        public static Bitmask<T> With<T>(this Bitmask<T> bitmask, IEnumerable<T> bits)
            where T: class
        {
            foreach (var bit in bits)
            {
                bitmask = bitmask.With(bit);
            }

            return bitmask;
        }
        
        public static BitmaskFilter<T> Include<T>(this BitmaskFilter<T> filter, IEnumerable<T> bits)
            where T: class
        {
            foreach (var bit in bits)
            {
                filter = filter.Include(bit);
            }

            return filter;
        }
        
        public static BitmaskFilter<T> Exclude<T>(this BitmaskFilter<T> filter, IEnumerable<T> bits)
            where T: class
        {
            foreach (var bit in bits)
            {
                filter = filter.Exclude(bit);
            }

            return filter;
        }
    }
}