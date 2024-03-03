using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.Timings
{
    public interface ITimeRange
    {
        bool IsInside(float time);
        bool IsOutside(float time);
        bool HasEntered(float previousTime, float time);
        bool HasExited(float previousTime, float time);
        float Evaluate(float time);
    }

    public interface ITimeRange<TData> : ITimeRange
    {
        public interface IWithDefault<out TDefault>
        {
            TDefault Default { get; }
        }

        bool IsInside(float time, out TData data);
        bool IsOutside(float time, out TData data);
        bool HasEntered(float previousTime, float time, out TData data);
        bool HasExited(float previousTime, float time, out TData data);
        float Evaluate(float time, out TData data);
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
            return time <= _range.x || time >= _range.y;
        }

        public bool HasEntered(float previousTime, float time)
        {
            return previousTime != time &&
                   IsOutside(previousTime) && IsInside(time);
        }

        public bool HasExited(float previousTime, float time)
        {
            return IsInside(previousTime) && IsOutside(time);
        }

        public float Evaluate(float time)
        {
            return Mathf.InverseLerp(_range.x, _range.y, time);
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
    public class TimeRangeComposite : ITimeRange, IEnumerable<TimeRange>
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

        public bool HasEntered(float previousTime, float time)
        {
            foreach (var range in _ranges)
            {
                if (range.HasEntered(previousTime, time))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasExited(float previousTime, float time)
        {
            foreach (var range in _ranges)
            {
                if (range.HasExited(previousTime, time))
                {
                    return true;
                }
            }

            return false;
        }

        public float Evaluate(float time)
        {
            foreach (var range in _ranges)
            {
                if (range.IsInside(time))
                {
                    return range.Evaluate(time);
                }
            }

            return 0;
        }

        public IEnumerator<TimeRange> GetEnumerator()
        {
            return ((IEnumerable<TimeRange>)_ranges).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    [Serializable]
    public struct TimeRange<TData> : ITimeRange<TData>
    {
        [SerializeField]
        private TimeRange _timeRange;

        [SerializeField]
        private TData _data;

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

        public bool HasEntered(float previousTime, float time)
        {
            return _timeRange.HasEntered(previousTime, time);
        }

        public bool HasExited(float previousTime, float time)
        {
            return _timeRange.HasExited(previousTime, time);
        }

        public float Evaluate(float time)
        {
            return _timeRange.Evaluate(time);
        }

        public bool IsInside(float time, out TData data)
        {
            data = _data;
            return IsInside(time);
        }

        public bool IsOutside(float time, out TData data)
        {
            data = _data;
            return IsOutside(time);
        }

        public bool HasEntered(float previousTime, float time, out TData data)
        {
            data = _data;
            return HasEntered(previousTime, time);
        }

        public bool HasExited(float previousTime, float time, out TData data)
        {
            data = _data;
            return HasExited(previousTime, time);
        }

        public float Evaluate(float time, out TData data)
        {
            data = _data;
            return Evaluate(time);
        }
    }

    [Serializable]
    public class TimeRangeComposite<TData> : ITimeRange<TData>, IEnumerable<TimeRange<TData>>
    {
        [Serializable]
        public class WithDefault : TimeRangeComposite<TData>, ITimePoint<TData>.IWithDefault<TData>
        {
            [SerializeField]
            private TData _default;

            public TData Default => _default;

            public WithDefault(TimeRange<TData>[] ranges, TData @default) : base(ranges)
            {
                _default = @default;
            }

            public override bool IsInside(float time, out TData data)
            {
                if (base.IsInside(time, out data))
                {
                    return true;
                }

                data = _default;
                return false;
            }

            public override bool IsOutside(float time, out TData data)
            {
                if (base.IsOutside(time, out data))
                {
                    return true;
                }

                data = _default;
                return false;
            }
        }

        [SerializeField]
        private TimeRange<TData>[] _ranges;

        public TimeRangeComposite(TimeRange<TData>[] ranges)
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

        public bool HasEntered(float previousTime, float time)
        {
            foreach (var range in _ranges)
            {
                if (range.HasEntered(previousTime, time))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasExited(float previousTime, float time)
        {
            foreach (var range in _ranges)
            {
                if (range.HasExited(previousTime, time))
                {
                    return true;
                }
            }

            return false;
        }

        public float Evaluate(float time)
        {
            foreach (var range in _ranges)
            {
                if (range.IsInside(time))
                {
                    return range.Evaluate(time);
                }
            }

            return 0;
        }

        public virtual bool IsInside(float time, out TData data)
        {
            data = default;

            foreach (var range in _ranges)
            {
                if (range.IsInside(time, out data))
                {
                    return true;
                }
            }

            return false;
        }

        public virtual bool IsOutside(float time, out TData data)
        {
            return !IsInside(time, out data);
        }

        public bool HasEntered(float previousTime, float time, out TData data)
        {
            data = default;

            foreach (var range in _ranges)
            {
                if (range.HasEntered(previousTime, time, out data))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasExited(float previousTime, float time, out TData data)
        {
            data = default;

            foreach (var range in _ranges)
            {
                if (range.HasExited(previousTime, time, out data))
                {
                    return true;
                }
            }

            return false;
        }

        public float Evaluate(float time, out TData data)
        {
            data = default;

            foreach (var range in _ranges)
            {
                if (range.IsInside(time))
                {
                    return range.Evaluate(time, out data);
                }
            }

            return 0;
        }

        public IEnumerator<TimeRange<TData>> GetEnumerator()
        {
            return ((IEnumerable<TimeRange<TData>>)_ranges).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
