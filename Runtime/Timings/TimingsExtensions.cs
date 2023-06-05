namespace Dre0Dru.Timings
{
    public static class TimingsExtensions
    {
        public static bool HasEntered<TTimeRange>(this TTimeRange timeRange, float previousTime, float currentTime)
            where TTimeRange : ITimeRange
        {
            return timeRange.IsOutside(previousTime) && timeRange.IsInside(currentTime);
        }

        public static bool HasExited<TTimeRange>(this TTimeRange timeRange, float previousTime, float currentTime)
            where TTimeRange : ITimeRange
        {
            return timeRange.IsInside(previousTime) && timeRange.IsOutside(currentTime);
        }

        public static bool IsTriggered<TTimePoint>(this TTimePoint timePoint, float previousTime, float currentTime)
            where TTimePoint : ITimePoint
        {
            return timePoint.IsBefore(previousTime) && timePoint.IsPast(currentTime);
        }

        public static bool IsTriggered<TTimePoint, TData>(this TTimePoint timePoint, float previousTime,
            float currentTime, out TData data)
            where TTimePoint : ITimePoint<TData>
        {
            data = timePoint.Data;
            return timePoint.IsTriggered(previousTime, currentTime);
        }
    }
}
