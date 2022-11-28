using System.Text.Json.Serialization;
using System.Xml.Serialization;
using SPP_Tracer.Results;
using System.Collections.Generic;


namespace SPP_Tracer.bufResults
{
    class methodInfo
    {
        [JsonPropertyName("name")]
        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; }

        [JsonPropertyName("class")]
        [XmlAttribute(AttributeName = "class")]
        public string className { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public double leadTime { get; set; }


        [JsonPropertyName("time")]
        [XmlAttribute(AttributeName = "time")]
        public string StringLeadTime { get { return $"{System.Math.Floor(leadTime)}ms"; } set { } }

        [JsonPropertyName("methods")]
        [XmlElement(ElementName = "method")]
        public List<methodInfo> Methods { get; set; }

        public methodInfo()
        {
            name = "";
            className = "";
            leadTime = -1;
            Methods = new List<methodInfo>();
        }

        internal methodInfo(MethodInfo _methodInfo)
        {
            name = _methodInfo.name;
            className = _methodInfo.className;
            leadTime = _methodInfo.leadTime;

            Methods = new List<methodInfo>();
            foreach (MethodInfo method in _methodInfo.Methods)
            {
                Methods.Add(new methodInfo(method));
            }
        }
    }
}
