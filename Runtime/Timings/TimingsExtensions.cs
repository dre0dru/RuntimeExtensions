namespace Dre0Dru.Timings
{
    //TODO Point/Range builders
    public static class TimingsExtensions
    {
        public static bool HasChanged(this ITimeRange timeRange, float previousTime, float time)
        {
            return timeRange.HasExited(previousTime, time) || timeRange.HasEntered(previousTime, time);
        }

        public static bool HasChanged<TData>(this ITimeRange<TData> timeRange, float previousTime, float time,
            out TData enteredData)
        {
            return timeRange.HasChanged(previousTime, time, out _, out enteredData);
        }

        public static bool HasChanged<TData>(this ITimeRange<TData> timeRange, float previousTime, float time,
            out TData exitedData, out TData enteredData)
        {
            var hasExited = timeRange.HasExited(previousTime, time, out exitedData);
            var hasEntered = timeRange.HasEntered(previousTime, time, out enteredData);

            return hasExited || hasEntered;
        }
    }
}
