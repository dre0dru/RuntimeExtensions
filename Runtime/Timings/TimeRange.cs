﻿using System;
using UnityEngine;

namespace Dre0Dru.Timings
{
    public interface ITimeRange
    {
        bool IsInside(float time);
        bool IsOutside(float time);
    }

    public interface ITimeRange<out TData> : ITimeRange
    {
        TData Data { get; }
    }

    [Serializable]
    public struct TimeRange : ITimeRange
    {
        [SerializeField]
        private Vector2 _range;

        public TimeRange(Vector2 minMax)
        {
            _range = minMax;
        }
        
        public TimeRange(float min, float max) : this(new Vector2(min, max))
        {
        }
        
        public TimeRange(double min, double max) : this(new Vector2((float)min, (float)max))
        {
        }

        public bool IsInside(float time)
        {
            return time >= _range.x && time <= _range.y;
        }

        public bool IsOutside(float time)
        {
            return !IsInside(time);
        }

        public static implicit operator TimeRange(Vector2 minMax)
        {
            return new TimeRange(minMax);
        } 
        
        public static implicit operator TimeRange((float min, float max) minMax)
        {
            return new TimeRange(minMax.min, minMax.max);
        } 
        
        public static implicit operator TimeRange((double min, double max) minMax)
        {
            return new TimeRange(minMax.min, minMax.max);
        } 
    }

    [Serializable]
    public struct TimeRangeComposite : ITimeRange
    {
        [SerializeField]
        private TimeRange[] _ranges;

        public TimeRangeComposite(TimeRange[] ranges)
        {
            _ranges = ranges;
        }

        public bool IsInside(float time)
        {
            foreach (var range in _ranges)
            {
                if (range.IsInside(time))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsOutside(float time)
        {
            return !IsInside(time);
        }
    }

    [Serializable]
    public struct TimeRange<TData> : ITimeRange<TData>
    {
        [SerializeField]
        private TimeRange _timeRange;

        [SerializeField]
        private TData _data;

        public TData Data => _data;

        public TimeRange(TimeRange timeRange, TData data)
        {
            _timeRange = timeRange;
            _data = data;
        }

        public bool IsInside(float time)
        {
            return _timeRange.IsInside(time);
        }

        public bool IsOutside(float time)
        {
            return _timeRange.IsOutside(time);
        }
    }

    [Serializable]
    public struct TimeRangeComposite<TData> : ITimeRange<TData>
    {
        [SerializeField]
        private TimeRangeComposite _timeRangeComposite;
        
        [SerializeField]
        private TData _data;

        public TData Data => _data;

        public TimeRangeComposite(TimeRangeComposite timeRangeComposite, TData data)
        {
            _timeRangeComposite = timeRangeComposite;
            _data = data;
        }

        public bool IsInside(float time)
        {
            return _timeRangeComposite.IsInside(time);
        }

        public bool IsOutside(float time)
        {
            return _timeRangeComposite.IsOutside(time);
        }
    }
}
