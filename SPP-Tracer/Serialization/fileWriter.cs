using System.IO;

namespace SPP_Tracer.Serialization
{
    public class fileWriter : IWriter
    {
        private string _destination;
        public fileWriter(string destination)
        {
            _destination = destination;
        }

        void IWriter.Write(string result)
        {
            using (StreamWriter writer = new StreamWriter(_destination, false))
            {
                writer.WriteLine(result);
            }
        }
    }
}
