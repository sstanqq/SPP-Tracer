using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SPP_Tracer.bufResults;

namespace SPP_Tracer.Results
{
    public class ThreadInfo
    {
        public int id { get; }
        public double leadTime { get; }
        public IReadOnlyList<MethodInfo> Methods { get; }

        internal ThreadInfo(threadInfo thread)
        {
            id = thread.id;
            leadTime = thread.leadTime;

            List<MethodInfo> methods = new List<MethodInfo>();

            foreach (methodInfo method in thread.Methods)
            {
                methods.Add(new MethodInfo(method));
            }
            Methods = methods;
        }
    }
}
