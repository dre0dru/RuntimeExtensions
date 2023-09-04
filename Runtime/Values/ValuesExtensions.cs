using System;
using System.Collections.Generic;

namespace Dre0Dru.Values
{
    public static class ValuesExtensions
    {
        public static bool TryToConsume<T>(this ref ConsumableValue<T> consumableValue, out T value)
        {
            value = default;
            
            if (!consumableValue.IsConsumed)
            {
                consumableValue.IsConsumed = true;
                value = consumableValue;
                return true;
            }

            return false;
        }
        
        public static bool IsValueChanged<T>(this ValueChangeBuffer<T> buffer)
            where T : IEquatable<T>
        {
            return !EqualityComparer<T>.Default.Equals(buffer.PreviousValue, buffer.CurrentValue);
        }
    }
}
