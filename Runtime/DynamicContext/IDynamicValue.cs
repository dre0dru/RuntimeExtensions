namespace Dre0Dru.DynamicContext
{
    public interface IDynamicValue
    {
        TValue GetValue<TValue>()
            where TValue : class;

        void SetValue<TValue>(TValue value)
            where TValue : class;
    }
}
