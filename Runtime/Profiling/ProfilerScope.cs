using System;
using UnityEngine.Profiling;

namespace Dre0Dru.Profiling
{
    public readonly struct ProfilerScope : IDisposable
    {
        public ProfilerScope(string name)
        {
            Profiler.BeginSample(name);
        }

        public void Dispose()
        {
            Profiler.EndSample();
        }
    }
}
