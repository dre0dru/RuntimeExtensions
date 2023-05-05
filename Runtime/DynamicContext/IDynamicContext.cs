namespace Dre0Dru.DynamicContext
{
    //TODO contexts merge: merge two diff contexts into one
    //TODO generic typed context which allows to search by subtype/implementation
    public interface IDynamicContext<in TKey>
    {
        void AddValue<TValue>(TKey key, TValue value)
            where TValue : class;

        void SetValue<TValue>(TKey key, TValue value)
            where TValue : class;

        TValue GetValue<TValue>(TKey key)
            where TValue : class;

        bool HasValue<TValue>(TKey key)
            where TValue : class;

        bool TryGetValue<TValue>(TKey key, out TValue value)
            where TValue : class;

        bool RemoveValue(TKey key);
    }
}
