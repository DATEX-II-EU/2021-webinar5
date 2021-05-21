using DemoSoapServer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DemoSoapServer.Data
{
    public class DataManager
    {
    
    public MessageContainer GetData()
    {
            MessageContainer data = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync("http://datex.vegagerdin.is/situationpublication3_1/SituationService/pullsnapshotdata").Result)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;

                    XmlSerializer serializer = new XmlSerializer(typeof(MessageContainer));
                    StringReader reader = new StringReader(apiResponse);
                    data = (MessageContainer)serializer.Deserialize(reader);

                }
            }

            return data;

    }

    }
}
