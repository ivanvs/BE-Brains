using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T10_P1_1.Controllers;
using T10_P1_1.Services;

namespace T10_P1_1.Tests.Controllers
{
    [TestClass]
    public class ControllerMockTest
    {
        [TestMethod]
        public void TestingMock()
        {
            var mockService = new Mock<IGreetingService>();
            mockService.Setup(x => x.Greet()).Returns("Zdravo Svete");

            var controller = new HomeController(mockService.Object);
            controller.Request = new System.Net.Http.HttpRequestMessage();
            controller.RequestContext = new System.Web.Http.Controllers.HttpRequestContext();

            Assert.AreEqual("Zdravo Svete", controller.GetGreeting());
        }
    }

}
