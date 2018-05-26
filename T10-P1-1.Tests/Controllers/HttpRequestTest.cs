using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T10_P1_1.Tests.Controllers
{
    [TestClass]
    public class HttpRequestTest
    {

        [TestMethod]
        public async Task GreetingEndpintShouldReturnHelloWorldMessage()
        {
            using (var server = TestServer.Create<Startup>())
            {
                var result = await server.HttpClient.GetAsync("api/home");
                string responseContent = await result.Content.ReadAsStringAsync();

                Assert.AreEqual("\"Hello World\"", responseContent);
            }
        }
    }

}
