using DemoSoapServer.Data;
using DemoSoapServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using DemoSoapServer;

namespace DemoSoapServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PullhttpController : ControllerBase
    {

        //Use HttpGet and return applicatiion/xml
        [HttpGet("")]
        [Produces("application/xml")]
        public async Task<ActionResult> PullPayload()
        {

            DataManager dataManager = new DataManager();
            MessageContainer msg = dataManager.GetData();
            if (msg != null)
            {              
                msg.exchangeInformation.exchangeContext.supplierOrCisRequester.internationalIdentifier.nationalIdentifier = "DEMO";
                msg.exchangeInformation.exchangeContext.supplierOrCisRequester.internationalIdentifier.country = "SE";
                msg.exchangeInformation.dynamicInformation.messageGenerationTimestamp = DateTime.UtcNow;             
            }
            else
            {
                //Todo add error handling / message here
                
            }

            //To get nicer namespaces
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("com", "http://datex2.eu/schema/3/common");
            ns.Add("sit", "http://datex2.eu/schema/3/situation");
            ns.Add("d2", "http://datex2.eu/schema/3/d2Payload");
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");

            string xmlString = msg.SerializeObject<MessageContainer>(ns);

            XmlDocument  xmlContent = new XmlDocument();
            xmlContent.LoadXml(xmlString);

            return new OkObjectResult(xmlContent);
        }
     
    }
}
