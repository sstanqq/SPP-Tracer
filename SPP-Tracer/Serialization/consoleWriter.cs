using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_Tracer.Serialization
{
    public class consoleWriter : IWriter
    {
        void IWriter.Write(string value)
        {
            Console.WriteLine(value);
        }
    }
}
