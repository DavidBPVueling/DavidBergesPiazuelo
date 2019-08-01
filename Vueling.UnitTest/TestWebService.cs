using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.UnitTest.ServiceReference;

namespace Vueling.UnitTest
{
    [TestClass]
    public class TestWebService
    {
        [TestMethod]
        public void TestCreate()
        {
            ServiceReference.WebServiceSoapClient ClienteSOAP = new WebServiceSoapClient();

            Assert.AreEqual(true, ClienteSOAP.Create());
        }

        [TestMethod]
        public void TestAdd()
        {
            ServiceReference.WebServiceSoapClient ClienteSOAP = new WebServiceSoapClient();
            Rebel rebel = new Rebel();
            rebel._name = "Yoda";
            rebel._planet = "Dagoba";
            

            Assert.AreEqual(true, ClienteSOAP.Add(rebel));
        }

        [TestMethod]
        public void TestGetById()
        {
            ServiceReference.WebServiceSoapClient ClienteSOAP = new WebServiceSoapClient();
            Rebel rebel = new Rebel();
            rebel._name = "Yoda";
            rebel._planet = "Dagoba";

            Assert.AreEqual(rebel._name, ClienteSOAP.GetById(rebel)._name);
        }

        [TestMethod]
        public void GetAll()
        {
            ServiceReference.WebServiceSoapClient ClienteSOAP = new WebServiceSoapClient();

            Assert.IsNotNull(ClienteSOAP.GetAll());
        }

        [TestMethod]
        public void TestUpdate()
        {
            ServiceReference.WebServiceSoapClient ClienteSOAP = new WebServiceSoapClient();
            Rebel rebel = new Rebel();
            rebel._name = "Yoda";
            rebel._planet = "Dagoba";

            string newName = "Obi Wan";
            string newPlanet = "Tattounie";

            Assert.AreEqual(true, ClienteSOAP.Update(rebel, newName, newPlanet));
        }

        [TestMethod]
        public void TestDelete()
        {
            ServiceReference.WebServiceSoapClient ClienteSOAP = new WebServiceSoapClient();
            Rebel rebel = new Rebel();
            rebel._name = "Yoda";
            rebel._planet = "Dagoba";

            Assert.AreEqual(true, ClienteSOAP.Delete(rebel));
        }

        [TestMethod]
        public void TestDeleteAll()
        {
            ServiceReference.WebServiceSoapClient ClienteSOAP = new WebServiceSoapClient();

            Assert.AreEqual(true, ClienteSOAP.DeleteAll());
        }
    }
}
