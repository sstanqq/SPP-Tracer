using System.Collections.Generic;
using SPP_Tracer.Result;

namespace SPP_Tracer
{
    internal class bufThreadInfo
    {
        public Stack<bufMethodInfo> RunningMethods = new Stack<bufMethodInfo>();

        public List<MethodInfo> Methods = new List<MethodInfo>();
    }
}
