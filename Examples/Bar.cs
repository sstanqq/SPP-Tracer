using System.Threading;
using SPP_Tracer;

namespace Examples
{
    internal class Bar
    {
        private ITracer _tracer;

        public Bar(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void InnerMethod()
        {
            _tracer.StartTrace();

            Thread.Sleep(500);

            _tracer.StopTrace();
        }
    }
}
