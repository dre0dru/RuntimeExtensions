namespace Dre0Dru.Timings
{
    public static class TimingsExtensions
    {
        public static bool HasEntered<TTimeRange>(this TTimeRange timeRange, float previousTime, float currentTime)
            where TTimeRange : ITimeRange
        {
            return timeRange.IsOutside(previousTime) && timeRange.IsInside(currentTime);
        }
        
        public static bool HasEntered<TTimeRange, TData>(this TTimeRange timeRange, float previousTime, 
            float currentTime, out TData data)
            where TTimeRange : ITimeRange<TData>
        {
            return timeRange.IsInside(currentTime, out data) && timeRange.IsOutside(previousTime);
        }

        public static bool HasExited<TTimeRange>(this TTimeRange timeRange, float previousTime, float currentTime)
            where TTimeRange : ITimeRange
        {
            return timeRange.IsInside(previousTime) && timeRange.IsOutside(currentTime);
        }
        
        public static bool HasExited<TTimeRange, TData>(this TTimeRange timeRange, float previousTime, 
            float currentTime, out TData data)
            where TTimeRange : ITimeRange<TData>
        {
            return timeRange.IsOutside(currentTime, out data) && timeRange.IsInside(previousTime);
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
            return timePoint.IsPast(currentTime, out data) && timePoint.IsBefore(previousTime);
        }
    }
}
