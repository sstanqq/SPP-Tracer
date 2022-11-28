using System.Text.Json;

using SPP_Tracer.bufResults;
using SPP_Tracer.Results;

namespace SPP_Tracer.Serialization
{
    // Класс реализующий json сериализацию
    class jsonSer : ISerialization
    {
        public string Serialize(TraceResult result)
        {
            var bufResult = new traceResult(result);
            var options = new JsonSerializerOptions { WriteIndented = true };

            return JsonSerializer.Serialize(bufResult, options);
        }
    }
}
