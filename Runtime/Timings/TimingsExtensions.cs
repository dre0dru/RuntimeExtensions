namespace Dre0Dru.Timings
{
    public static class TimingsExtensions
    {
        public static bool HasChanged(this TimeRangeComposite timeRange, float previousTime, float time)
        {
            return timeRange.HasExited(previousTime, time) || timeRange.HasEntered(previousTime, time);
        }

        public static bool HasChanged<TData>(this TimeRangeComposite<TData> timeRange, float previousTime, float time,
            out TData enteredData)
        {
            return timeRange.HasChanged(previousTime, time, out _, out enteredData);
        }

        public static bool HasChanged<TData>(this TimeRangeComposite<TData> timeRange, float previousTime, float time,
            out TData exitedData, out TData enteredData)
        {
            var hasExited = timeRange.HasExited(previousTime, time, out exitedData);
            var hasEntered = timeRange.HasEntered(previousTime, time, out enteredData);

            return hasExited || hasEntered;
        }
    }
}
