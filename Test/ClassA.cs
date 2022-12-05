using System.Threading;
using SPP_Tracer;


namespace Test
{
    internal class ClassA
    {
        private ITracer _tracer;

        public ClassA(ITracer tracer)
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
