namespace DiContainertTests
{
    using System;
    using Depedencies.DiContainer_poc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SingletonServiceTests
    {
        private Container container;
        private GetDISeriveCollection services;

        [TestInitialize]
        public void SetUp()
        {
            services = new GetDISeriveCollection();
            
            //Registers the services
            services.AddSingleton<RandomGuidGenerator>(new RandomGuidGenerator());
            
            //build conainer from services 
            container = services.BuildContainer();
        }

        [TestMethod]
        public void TestServiceRegisterd()
        {            
            Assert.AreNotEqual(null, container.GetService<RandomGuidGenerator>());
        }

        [TestMethod]
        public void TestServiceNotRegisterd_Returns_Null()
        {
            try {
                var service = container.GetService<GetDISeriveCollection>();
            }
            catch(Exception )
            {
                Assert.Fail($"Service is not registered..");
            }
        }

        [TestMethod]
        public void TestSingleTonServiceResolved()
        {
            var service1 = container.GetService<RandomGuidGenerator>();
            var service2 = container.GetService<RandomGuidGenerator>();
            
            //Service resolved for singleton
            Assert.IsNotNull(service1);
            Assert.IsNotNull(service2);

            var service1Guid = service1.UniqueGuid;
            var service2Guid = service2.UniqueGuid;

            // Guid is unique so it's singleton 
            Assert.AreEqual(service1Guid, service2Guid);
        }
    }
}
