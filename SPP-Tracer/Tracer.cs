using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;

using SPP_Tracer.Results;
using SPP_Tracer.bufResults;

namespace SPP_Tracer
{
    // Реализуем интерфес 
    public class Tracer
    {
        private traceResult bufResult;
        private ConcurrentDictionary<int, ConcurrentStack<stackMethodInfo>> _methodOrder;

        private object locker = new();

        // Конструктор 
        public Tracer()
        {
            bufResult = new traceResult();
            _methodOrder = new ConcurrentDictionary<int, ConcurrentStack<stackMethodInfo>>();
        }

        private threadInfo GetThreadId()
        {
            threadInfo currThreadInfo;
            int currId = Thread.CurrentThread.ManagedThreadId;
            currThreadInfo = bufResult.Threads.Find(x => (x.Id == currId));
            if (currThreadInfo == null)
            {
                bufResult?.Threads.Add(new threadInfo(currId));
                currThreadInfo = bufResult?.Threads[bufResult.Threads.Count - 1];
            }
            return currThreadInfo;
        }

        // Начало 
        public void StartTrace()
        {
            methodInfo currMethodInfo = new methodInfo();
            StackTrace stackTrace = new StackTrace();
            currMethodInfo.name = stackTrace.GetFrame(1).GetMethod().Name;
            currMethodInfo.className = stackTrace.GetFrame(1).GetMethod().DeclaringType.Name;
            currMethodInfo.leadTime = -1;

            stackMethodInfo stackMethod = new stackMethodInfo(new Stopwatch(), currMethodInfo);

            int threadId = Thread.CurrentThread.ManagedThreadId;
            _methodOrder.TryAdd(threadId, new ConcurrentStack<stackMethodInfo>());
            _methodOrder[threadId].Push(stackMethod);

            stackMethod.MethodStopwatch.Start();
        }

        // Конец
        public void StopTrace()
        {
            stackMethodInfo parentStackMethodInfo;
            stackMethodInfo currStackMethodInfo;
            int threadId = Thread.CurrentThread.ManagedThreadId;
            _methodOrder[threadId].TryPop(out currStackMethodInfo);

            currStackMethodInfo.MethodStopwatch?.Stop();
            currStackMethodInfo.Method.leadTime = currStackMethodInfo.MethodStopwatch.Elapsed.TotalMilliseconds;

            if (_methodOrder[threadId].TryPop(out parentStackMethodInfo))
            {
                parentStackMethodInfo.Method.Methods.Add(currStackMethodInfo.Method);
                _methodOrder[threadId].Push(parentStackMethodInfo);
            }
            else
            {
                lock (locker)
                {
                    GetThreadId().Methods.Add(currStackMethodInfo.Method);
                }
            }

        }

        public TraceResult GetTraceResult()
        {
            return new TraceResult(bufResult);
        }
    }
}
