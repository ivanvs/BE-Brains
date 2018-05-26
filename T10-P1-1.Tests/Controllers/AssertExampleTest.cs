using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using T10_P1_1.Controllers;

namespace T10_P1_1.Tests.Controllers
{
    /// <summary>
    /// Summary description for AssertExampleTest
    /// </summary>
    [TestClass]
    public class AssertExampleTest
    {
        [TestMethod]
        public void GreetingShouldReturnMessage()
        {
            var controller = new HomeController();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            controller.RequestContext = new System.Web.Http.Controllers.HttpRequestContext();

            Assert.AreEqual("Hello World", controller.GetGreeting());
        }

    }
}
