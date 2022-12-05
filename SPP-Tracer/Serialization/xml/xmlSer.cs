using System.IO;
using System.Xml.Serialization;

namespace SPP_Tracer.Serialization.xml
{
    // Класс реализующий xml сериализацию
    public class XmlTraceSerializer : ISerialization
    {
        string ISerialization.Serialize(Result.TraceResult value)
        {
            var traceResult = new TraceResult(value);

            XmlSerializer xmlSerializer = new XmlSerializer(traceResult.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, traceResult);
                return textWriter.ToString();
            }
        }
    }
}
