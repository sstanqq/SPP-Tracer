using System.Text.Json.Serialization;
using System.Xml.Serialization;
using SPP_Tracer.Results;
using System.Collections.Generic;

namespace SPP_Tracer.bufResults
{
    class threadInfo
    {
        [JsonPropertyName("id")]
        [XmlAttribute(AttributeName = "id")]
        public int id { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public double leadTime
        {
            get
            {
                double time = 0;
                foreach (methodInfo method in Methods)
                {
                    time += method.leadTime;
                }
                return time;
            }
            set { }
        }

        [JsonPropertyName("time")]
        [XmlAttribute(AttributeName = "time")]
        public string StringLeadTime { get { return $"{System.Math.Floor(leadTime)}ms"; } set { } }

        [JsonPropertyName("methods")]
        [XmlElement(ElementName = "method")]
        public List<methodInfo> Methods { get; set; }

        public threadInfo()
        {
            Methods = new List<methodInfo>();
        }

        internal threadInfo(int _id)
        {
            id = _id;
            Methods = new List<methodInfo>();
        }

        internal threadInfo(ThreadInfo thread)
        {
            id = thread.id;
            leadTime = thread.leadTime;

            List<methodInfo> methods = new List<methodInfo>();

            foreach (MethodInfo method in thread.Methods)
            {
                methods.Add(new methodInfo(method));
            }
            Methods = methods;
        }
    }
}
