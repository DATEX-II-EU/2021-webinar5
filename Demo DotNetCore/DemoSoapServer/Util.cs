using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DemoSoapServer
{
    public static class Util
    {
        public static string SerializeObject<T>(this T toSerialize, XmlSerializerNamespaces ns = null)
        {
           
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (StringWriter textWriter = new StringWriter())
            {
                if (ns != null) 
                { 
                    xmlSerializer.Serialize(textWriter, toSerialize,ns);
                }
                else 
                { 
                    xmlSerializer.Serialize(textWriter, toSerialize);
                }
                return textWriter.ToString();
            }
        }
    }
}
