using System.Collections.Generic;

namespace SPP_Tracer.Result
{
    public class MethodInfo
    {
        public string name { get; }
        public string typeName { get; }
        public long milliseconds { get; }
        public IReadOnlyList<MethodInfo> Methods { get; }

        public MethodInfo(string name, string typeName, long milliseconds, IReadOnlyList<MethodInfo> methods)
        {
            name = name;
            typeName = typeName;
            milliseconds = milliseconds;
            Methods = methods;
        }
    }
}
