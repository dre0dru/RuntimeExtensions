﻿using System;
using UnityEngine;

namespace Dre0Dru.Timings
{
    public interface ITimePoint
    {
        bool IsBefore(float time);
        bool IsPast(float time);
    }

    public interface ITimePoint<TData> : ITimePoint
    {
        bool IsBefore(float time, out TData data);
        bool IsPast(float time, out TData data);
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
            _time = (float)time;
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
    public class TimePointComposite : ITimePoint
    {
        [SerializeField]
        private TimePoint[] _points;

        public TimePointComposite(TimePoint[] points)
        {
            _points = points;
        }

        public bool IsBefore(float time)
        {
            foreach (var point in _points)
            {
                if (point.IsBefore(time))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsPast(float time)
        {
            return !IsBefore(time);
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

        public bool IsBefore(float time, out TData data)
        {
            data = _data;
            return IsBefore(time);
        }

        public bool IsPast(float time, out TData data)
        {
            data = _data;
            return IsPast(time);
        }
    }

    [Serializable]
    public class TimePointComposite<TData> : ITimePoint<TData>
    {
        [Serializable]
        public class WithDefault : TimePointComposite<TData>
        {
            [SerializeField]
            private TData _default;

            public TData Default => _default;

            public WithDefault(TimePoint<TData>[] points, TData @default) : base(points)
            {
                _default = @default;
            }
        }
        
        [SerializeField]
        private TimePoint<TData>[] _points;

        public TimePointComposite(TimePoint<TData>[] points)
        {
            _points = points;
        }

        public bool IsBefore(float time)
        {
            foreach (var point in _points)
            {
                if (point.IsBefore(time))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsPast(float time)
        {
            return !IsBefore(time);
        }

        public bool IsBefore(float time, out TData data)
        {
            data = default;
            
            foreach (var point in _points)
            {
                if (point.IsBefore(time, out data))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsPast(float time, out TData data)
        {
            return !IsBefore(time, out data);
        }
    }

}
