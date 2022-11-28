using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_Tracer
{
    class fileWriter
    {
        private readonly string _filePath;

        public fileWriter(string filePath)
        {
            _filePath = filePath;
        }

        public void write(string value)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, false))
            {
                // Ассинхронно записываем в файл
                writer.WriteLineAsync(value);
            }
        }
    }
}
