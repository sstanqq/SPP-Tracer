using System.IO;
using System.Xml;
using System.Xml.Serialization;

using SPP_Tracer.bufResults;

namespace SPP_Tracer.Serialization
{
    // Класс реализующий xml сериализацию
    class xmlSer : ISerialization
    {
        public string Serialize(Results.TraceResult result)
        {
            traceResult bufResult = new traceResult(result);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(traceResult));

            var settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t"
            };

            using (StringWriter textWriter = new StringWriter())
            {
                using (var writer = XmlWriter.Create(textWriter, settings))
                {
                    xmlSerializer.Serialize(writer, bufResult);
                }
                return textWriter.ToString();
            }
        }
    }
}
