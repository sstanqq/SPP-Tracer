using SPP_Tracer.Result;

namespace SPP_Tracer.Serialization
{
    // Интерфейс сериализации
    public interface ISerialization
    {
        string Serialize(TraceResult value);
    }
}
