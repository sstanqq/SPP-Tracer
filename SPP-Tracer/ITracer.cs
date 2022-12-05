﻿using SPP_Tracer.Result;

namespace SPP_Tracer
{
    public interface ITracer
    {
        // вызывается в начале замеряемого метода
        void StartTrace();
        // вызывается в конце замеряемого метода 
        void StopTrace();
        // получить результаты измерений  
        TraceResult GetTraceResult();
    }
}
