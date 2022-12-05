using System.Text.Json;

namespace SPP_Tracer.Serialization.json
{
    // Класс реализующий json сериализацию
    public class jsonSer : ISerialization
    {
        string ISerialization.Serialize(Result.TraceResult value)
        {
            var traceResult = new TraceResult(value);

            return JsonSerializer.Serialize(traceResult);
        }
    }
}
