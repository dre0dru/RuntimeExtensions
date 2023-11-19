using System;

namespace Dre0Dru.Values
{
    public class CapturedValue<T>
    {
        private Func<T> _func;

        public T Value => _func();

        public CapturedValue(Func<T> func)
        {
            Capture(func);
        }

        public void Capture(Func<T> func)
        {
            _func = func;
        }
    }
}
