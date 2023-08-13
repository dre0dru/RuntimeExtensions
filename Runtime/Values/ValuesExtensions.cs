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
    }
}
