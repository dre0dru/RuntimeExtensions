using System;
using UnityEngine;

namespace Dre0Dru.Observables
{
    //TODO IObservable?
    [Serializable]
    public class Observable<T>
        where T: IEquatable<T>
    {
        public delegate void ValueChangedEvent(T previous, T current);

        public event ValueChangedEvent ValueChanged;
        
        [SerializeField]
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                var previous = _value;
                _value = value;
                if (!previous.Equals(_value))
                {
                    ValueChanged?.Invoke(previous, _value);
                }
            }
        }

        public Observable() : this(default)
        {
            
        }

        public Observable(T value)
        {
            _value = value;
        }

        public static implicit operator T(Observable<T> observable) =>
            observable._value;
        
        public static implicit operator Observable<T>(T value) =>
            new Observable<T>(value);
    }
}
