namespace Dre0Dru.DynamicContext
{
    public static class DynamicContextExtensions
    {
        public static void AddValue<TKey, TValue>(this IDynamicContext<TKey> dynamicContext,
            TKey key, TValue value)
            where TValue : struct =>
            dynamicContext.AddValue(key, new BoxedValue<TValue>(value));

        public static void SetValue<TKey, TValue>(this IDynamicContext<TKey> dynamicContext,
            TKey key, TValue value)
            where TValue : struct
        {
            dynamicContext.GetValue<BoxedValue<TValue>>(key).Value = value;
        }

        public static TValue GetValue<TKey, TValue>(this IDynamicContext<TKey> dynamicContext,
            TKey key)
            where TValue : struct =>
            dynamicContext.GetValue<BoxedValue<TValue>>(key);

        public static bool HasValue<TKey, TValue>(this IDynamicContext<TKey> dynamicContext,
            TKey key)
            where TValue : struct =>
            dynamicContext.HasValue<BoxedValue<TValue>>(key);

        public static bool TryGetValue<TKey, TValue>(this IDynamicContext<TKey> dynamicContext,
            TKey key, out TValue value)
            where TValue : struct
        {
            if (dynamicContext.TryGetValue(key, out BoxedValue<TValue> boxedValue))
            {
                value = boxedValue;
                return true;
            }

            value = default;
            return false;
        }
    }
}
