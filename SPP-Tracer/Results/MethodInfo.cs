using System.Collections.Generic;
using SPP_Tracer.bufResults;

namespace SPP_Tracer.Results
{
    public class MethodInfo
    {
        public string name { get; }
        public string className { get; }
        public double leadTime { get; }
        public IReadOnlyList<MethodInfo> Methods { get; }

        internal MethodInfo(methodInfo _methodInfo)
        {
            name = _methodInfo.name;
            className = _methodInfo.className;
            leadTime = _methodInfo.leadTime;

            List<MethodInfo> methods = new List<MethodInfo>();

            foreach (methodInfo method in _methodInfo.Methods)
            {
                methods.Add(new MethodInfo(method));
            }
            Methods = methods;

        }
    }
}
