using System.Collections.Generic;
using System.Diagnostics;
using SPP_Tracer.Result;

namespace SPP_Tracer
{
    internal class bufMethodInfo
    {
        public string name { get; set; }
        public string typeName { get; set; }
        public Stopwatch clock { get; set; } = new Stopwatch();

        public long milliseconds { get; set; }

        public List<MethodInfo> Methods = new List<MethodInfo>();

        public void UpdateMilliseconds()
        {
            milliseconds = clock.ElapsedMilliseconds;
        }
    }
}
