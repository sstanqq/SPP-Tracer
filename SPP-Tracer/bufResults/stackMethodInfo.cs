using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SPP_Tracer.bufResults
{
    internal class stackMethodInfo
    {
        internal methodInfo Method;
        internal Stopwatch MethodStopwatch;

        internal stackMethodInfo(Stopwatch methodStopwatch, methodInfo method)
        {
            Method = method;
            MethodStopwatch = methodStopwatch;
        }
    }
}
