using SPP_Tracer;

namespace Test
{
    internal class ClassB
    {
        private ClassA _A;
        private ITracer _tracer;

        public ClassB(ITracer tracer)
        {
            _tracer = tracer;
            _A = new ClassA(tracer);
        }

        public void MyMethod()
        {
            _tracer.StartTrace();

            _A.InnerMethod();

            _tracer.StopTrace();
        }
    }
}
