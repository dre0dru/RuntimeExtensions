using System;

namespace Dre0Dru.Values
{
    [Serializable]
    public sealed class Emitter : IDisposable
    {
        public event Action OnEvent;

        public void Invoke()
        {
            OnEvent?.Invoke();
        }
        
        public void Dispose()
        {
            OnEvent = null;
        }
    }
    
    [Serializable]
    public sealed class Emitter<T> : IDisposable
    {
        public event Action<T> OnEvent;

        public void Invoke(T value)
        {
            OnEvent?.Invoke(value);
        }
        
        public void Dispose()
        {
            OnEvent = null;
        }
    }
}
