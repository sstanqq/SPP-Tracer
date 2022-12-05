using System.Collections.Generic;

namespace SPP_Tracer.Result
{
    public class TraceResult
    {
        public IReadOnlyList<ThreadInfo> Threads { get; }

        public TraceResult(IReadOnlyList<ThreadInfo> threads)
        {
            Threads = threads;
        }
    }
}
