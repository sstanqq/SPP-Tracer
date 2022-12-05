using System.Threading.Tasks;
using SPP_Tracer;
using SPP_Tracer.Serialization;
using SPP_Tracer.Serialization.json;
using SPP_Tracer.Serialization.xml;

namespace Examples
{
    class Program
    {
        public delegate void ThreadStart();

        static private ITracer _tracer = new Tracer();


        static void Main(string[] args)
        {
            Foo foo = new Foo(_tracer);

            var task1 = new Task(() => {
                foo.MyMethod();
                foo.MyMethod();
            });

            var task2 = new Task(() => foo.MyMethod());
            var task3 = new Task(() => foo.MyMethod());

            task1.Start();
            task2.Start();
            task3.Start();

            task1.Wait();
            task2.Wait();
            task3.Wait();

            var result = _tracer.GetTraceResult();


            ISerialization traceSerializer = new jsonSer();

            IWriter writer = new fileWriter("test.json");
            writer.Write(traceSerializer.Serialize(result));

            writer = new consoleWriter();
            writer.Write(traceSerializer.Serialize(result));
        }
    }
}
