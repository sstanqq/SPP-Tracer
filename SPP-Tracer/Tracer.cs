using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;

using SPP_Tracer.Result;

namespace SPP_Tracer
{
    public class Tracer : ITracer
    {
        private ConcurrentDictionary<int, bufThreadInfo> _threads;

        public Tracer()
        {
            _threads = new ConcurrentDictionary<int, bufThreadInfo>();
        }

        TraceResult ITracer.GetTraceResult()
        {
            List<ThreadInfo> threads = new List<ThreadInfo>();

            foreach (var threadId in _threads.Keys)
            {
                threads.Add(new ThreadInfo(threadId, _threads[threadId].Methods));
            }

            return new TraceResult(threads);
        }

        void ITracer.StartTrace()
        {
            int threadId = Environment.CurrentManagedThreadId;
            _threads.GetOrAdd(threadId, new bufThreadInfo());

            var stackTrace = new StackTrace();
            var method = stackTrace.GetFrame(1).GetMethod();

            bufMethodInfo _methodInfo = new bufMethodInfo();
            _methodInfo.name = method.Name;
            _methodInfo.typeName = method.DeclaringType.Name;
            _methodInfo.clock.Start();

            _threads[threadId].RunningMethods.Push(_methodInfo);
        }

        void ITracer.StopTrace()
        {
            int threadId = Environment.CurrentManagedThreadId;
            var bufferMethodInfo = _threads[threadId].RunningMethods.Pop();

            bufferMethodInfo.clock.Stop();
            bufferMethodInfo.UpdateMilliseconds();

            var methodInfo = new MethodInfo(bufferMethodInfo.name, bufferMethodInfo.typeName,
                                            bufferMethodInfo.milliseconds, bufferMethodInfo.Methods);

            if (_threads[threadId].RunningMethods.Count == 0)
            {
                _threads[threadId].Methods.Add(methodInfo);
            }
            else
            {
                _threads[threadId].RunningMethods.Peek().Methods.Add(methodInfo);
            }
        }
    }
}
