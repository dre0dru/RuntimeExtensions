namespace Dre0Dru.Tokens
{
    public class PollingToken<T>
    {
        public T Value { get; protected set; }
        public bool ValueChanged { get; protected set; }

        public PollingToken() : this(default)
        {
        }

        public PollingToken(T initialValue)
        {
            Value = initialValue;
            ValueChanged = false;
        }

        public void ChangeValue(T value)
        {
            Value = value;
            ValueChanged = true;
        }

        public void Reset(T value)
        {
            Value = value;
            Reset();
        }

        public void Reset()
        {
            ValueChanged = false;
        }
    }
}
