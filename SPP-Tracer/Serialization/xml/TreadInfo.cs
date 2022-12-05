using System.Xml.Schema;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace SPP_Tracer.Serialization.xml
{
    public class ThreadInfo
    {
        [XmlAttribute(AttributeName = "id", Form = XmlSchemaForm.Unqualified)]
        public int ThreadId { get; set; }

        [XmlAttribute(AttributeName = "time", Form = XmlSchemaForm.Unqualified)]
        public string Milliseconds { get; set; }

        [XmlElement(ElementName = "method")]
        public List<MethodInfo> Methods { get; set; } = new List<MethodInfo>();

        public ThreadInfo() { }
        public ThreadInfo(Result.ThreadInfo threadInfo)
        {
            ThreadId = threadInfo.threadId;
            Milliseconds = $"{threadInfo.milliseconds}ms";

            foreach (var method in threadInfo.Methods)
            {
                Methods.Add(new MethodInfo(method));
            }
        }
    }
}
