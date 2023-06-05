using System;
using UnityEngine;

namespace Dre0Dru.Timings
{
    public interface ITimePoint
    {
        bool IsBefore(float time);
        bool IsPast(float time);
    }

    public interface ITimePoint<out TData> : ITimePoint
    {
        TData Data { get; }
    }

    [Serializable]
    public struct TimePoint : ITimePoint
    {
        [Range(0.0f, 1.0f)]
        [SerializeField]
        private float _time;

        public TimePoint(float time)
        {
            _time = time;
        }

        public TimePoint(double time)
        {
            _time = (float) time;
        }

        public bool IsBefore(float time)
        {
            return time < _time;
        }

        public bool IsPast(float time)
        {
            return !IsBefore(time);
        }
        
        public static implicit operator TimePoint(float time)
        {
            return new TimePoint(time);
        }
        
        public static implicit operator TimePoint(double time)
        {
            return new TimePoint(time);
        }
    }
    
    [Serializable]
    public struct TimePoint<TData> : ITimePoint<TData>
    {
        [SerializeField]
        private TimePoint _timePoint;
        
        [SerializeField]
        private TData _data;

        public TData Data => _data;

        public TimePoint(TimePoint timePoint, TData data)
        {
            _timePoint = timePoint;
            _data = data;
        }

        public bool IsBefore(float time)
        {
            return _timePoint.IsBefore(time);
        }

        public bool IsPast(float time)
        {
            return _timePoint.IsPast(time);
        }
    }
}
