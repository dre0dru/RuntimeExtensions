using System;

namespace Dre0Dru.Buildables
{
    public static class BuildablesExtensions
    {
        public static T Unwrap<T>(this Buildable<T> buildable) =>
            buildable;

        public static T Unwrap<TPrevious, T>(this Buildable<TPrevious, T> buildable) =>
            buildable;

        public static Buildable<T> Setup<T>(this Buildable<T> buildable, Action<T> callback)
        {
            callback(buildable);

            return buildable;
        }
        
        public static Buildable<TPrevious, T> Setup<TPrevious, T>(this Buildable<TPrevious, T> buildable, 
            Action<T> callback)
        {
            callback(buildable);

            return buildable;
        }
    }
}
