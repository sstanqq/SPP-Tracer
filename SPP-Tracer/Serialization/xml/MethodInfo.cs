using System.Xml.Schema;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace SPP_Tracer.Serialization.xml
{
    public class MethodInfo
    {
        [XmlAttribute(AttributeName = "name", Form = XmlSchemaForm.Unqualified)]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "class", Form = XmlSchemaForm.Unqualified)]
        public string TypeName { get; set; }


        [XmlAttribute(AttributeName = "time", Form = XmlSchemaForm.Unqualified)]
        public string Time { get; set; }

        [XmlElement(ElementName = "method")]
        public List<MethodInfo> Methods { get; set; } = new List<MethodInfo>();

        public MethodInfo() { }
        public MethodInfo(Result.MethodInfo methodInfo)
        {
            Name = methodInfo.name;
            TypeName = methodInfo.typeName;
            Time = $"{methodInfo.milliseconds}ms";

            foreach (var method in methodInfo.Methods)
            {
                Methods.Add(new MethodInfo(method));
            }

        }
    }
}
