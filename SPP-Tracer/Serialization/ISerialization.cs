using SPP_Tracer.Results;

namespace SPP_Tracer.Serialization
{
    // Интерфейс сериализации
    public interface ISerialization
    {
        string Serialize(TraceResult value);
    }
}
