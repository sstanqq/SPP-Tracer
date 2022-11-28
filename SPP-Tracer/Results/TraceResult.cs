using System.Xml.Serialization;
using System.Collections.Generic;
using SPP_Tracer.bufResults;

namespace SPP_Tracer.Results
{
    public class TraceResult
    {
        public IReadOnlyList<ThreadInfo> Threads { get; }

        internal TraceResult(traceResult result)
        {
            List<ThreadInfo> threads = new List<ThreadInfo>();

            foreach (threadInfo thread in result.Threads)
            {
                threads.Add(new ThreadInfo(thread));
            }

            Threads = threads;
        }
    }
}
