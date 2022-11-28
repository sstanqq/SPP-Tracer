using System.Xml.Serialization;
using System.Text.Json.Serialization;
using SPP_Tracer.Results;
using System.Collections.Generic;

namespace SPP_Tracer.bufResults
{
    [XmlRoot(ElementName = "root")]
    class traceResult
    {
        [JsonPropertyName("threads")]
        [XmlElement(ElementName = "thread")]
        public List<threadInfo> Threads { get; set; }

        public traceResult()
        {
            Threads = new List<threadInfo>();
        }

        internal traceResult(TraceResult result)
        {
            List<threadInfo> threads = new List<threadInfo>();

            foreach (ThreadInfo thread in result.Threads)
            {
                threads.Add(new threadInfo(thread));
            }
            Threads = threads;
        }
    }
}
