using System.Collections.Generic;
using System.Linq;

namespace SPP_Tracer.Result
{
    public class ThreadInfo
    {
        public int threadId { get; }
        public long milliseconds { get; }
        public IReadOnlyList<MethodInfo> Methods { get; }

        public ThreadInfo(int id, IReadOnlyList<MethodInfo> methods)
        {
            threadId = id;
            Methods = methods;

            milliseconds = methods.Sum(method => method.milliseconds);
        }
    }
}
