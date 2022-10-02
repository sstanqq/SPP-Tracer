using System;

namespace SPP_Tracer
{
    public interface ITracer
    {
        // Вызывается в начале замеряемого метода
        void StartTrace();

        // Вызывается в конце замеряемого метода
        void StopTrace();

        // получить результаты измерений
        //TraceResult GetTraceResult();
    }
}
