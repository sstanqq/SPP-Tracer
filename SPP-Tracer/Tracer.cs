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

    // Реализовываем интерфейс ITrace
    public class Tracer : ITracer
    {
        // Возвращает кол-во тактов на момент вызова
        public static long GetTimestamp()
        {
            return DateTime.UtcNow.Ticks;
        }

        // Запущен ли таймер
        private bool isRunning;
        // Число тактов на момент запуска
        private long startTimeStamp;
        // Общее число затраченных тактов
        private long totalTacts;

        public void StartTrace()
        {
            if (!isRunning)
            {
                startTimeStamp = GetTimestamp();
                isRunning = true;
            }
        }

        public void StopTrace()
        {
            if (isRunning)
            {
                long endTimeStamp = GetTimestamp();
                long tactsThisPeriod = endTimeStamp - startTimeStamp;
                totalTacts += tactsThisPeriod;
                isRunning = false;

                if (totalTacts < 0)
                {
                    // Для измерения небольших периодов времени(тк могут возвращать отрицательные значения)

                    totalTacts = 0;
                }
            }
        }
    }
}
