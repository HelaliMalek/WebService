using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using Newtonsoft.Json;

namespace LemonWayWebService
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "LemonWay")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
   
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
       
        private static string JsonError(string text)
        {
            var jsonRequest = new StringBuilder();
            var sw = new StringWriter(jsonRequest);
            using (var json = new JsonTextWriter(sw))
            {
                json.WriteStartObject();
                 json.WritePropertyName("IsValid");
                 json.WriteValue(false);
                json.WritePropertyName("Error");
                json.WriteValue(text);
                json.WriteEndObject();
            }
            return jsonRequest.ToString();
        }
        private static int GetFibonacci(int n)
        {
           
            if (n < 1 || n > 100) return -1;
            var a = 0;
            var b = 1;
            for (var i = 0; i < n; i++)
            {
                var temp = a;
                a = b;
                b = temp + b;
            }
         
            return a;
            
        }
        private static string ConvertXmlToJson(string xmlDoc)
        { var  xml = new XmlDocument();
            try
            {
               xml.LoadXml(xmlDoc);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return JsonError("Bad Xml format");
            }
            return JsonConvert.SerializeXmlNode(xml);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int Fibonacci(int n) => GetFibonacci(n);

        [WebMethod]
        [ScriptMethod (ResponseFormat = ResponseFormat.Json)]
        public string XmlToJson(string xml) => ConvertXmlToJson(xml);

    }
}
