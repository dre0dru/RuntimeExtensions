namespace Dre0Dru.DynamicContext
{
    //TODO events on value change, probably as a decorator
    //TODO DynamicValueReference that contains key and events 
    public interface IDynamicValue
    {
        TValue GetValue<TValue>()
            where TValue : class;

        void SetValue<TValue>(TValue value)
            where TValue : class;
    }
}
