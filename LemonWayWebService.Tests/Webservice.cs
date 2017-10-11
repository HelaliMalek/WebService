using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
namespace LemonWayWebService.Tests
{
    [TestClass]
    public class Webservice
    {
        [TestMethod]
        public void GetFibonacci()
        {
            var webService = new WebService();
            var result = webService.Fibonacci(1);
            Assert.AreEqual(1, result);
            var result1 = webService.Fibonacci(2);
            Assert.AreEqual(1, result1);
            var result2 = webService.Fibonacci(3);
            Assert.AreEqual(2, result2);
            var result3 = webService.Fibonacci(4);
            Assert.AreEqual(3, result3);
            var result4 = webService.Fibonacci(5);
            Assert.AreEqual(5, result4);
            var result5 = webService.Fibonacci(6);
            Assert.AreEqual(8, result5);
            var result6 = webService.Fibonacci(-100);
            Assert.AreEqual(-1, result6);
            var result7 = webService.Fibonacci(1000);
            Assert.AreEqual(-1, result7);
        }

        [TestMethod]

        public void GetXmltoJson()
        {
            var webService = new WebService();

            var resulta = webService.XmlToJson("<foo>bar</foo>");
            Assert.AreEqual("{\"foo\":\"bar\"}", resulta);

            var resulta1 = webService.XmlToJson("<foo>hello</bar>");
            Assert.AreEqual("{\"IsValid\":false,\"Error\":\"Bad Xml format\"}", resulta1);

        }
    }
}
