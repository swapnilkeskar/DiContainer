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

            //Registers the services.AddSingleton<T>(TService T) 
            services.AddSingleton<RandomGuidGenerator>(new RandomGuidGenerator());
            
            //build conainer from services 
            container = services.BuildContainer();
        }

        [TestMethod]
        public void ServiceRegisterd_Test()
        {            
            Assert.AreNotEqual(null, container.GetService<RandomGuidGenerator>());
        }

        [TestMethod]
        public void ServiceNotRegisterd_Returns_Null_Test()
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
        public void Register_SingleTonService_With_ServiceType_Parameter_Resolved_Test()
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

        [TestMethod]
        public void Register_SingleTonService_Without_ServiceType_Parameter_Resolved_Test()
        {
            ClearServiceCollection();

            //Registers the services.AddSingleton<T>() 
            services.AddSingleton<RandomGuidGenerator>();

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

        
        public void ClearServiceCollection()
        {
            services.Clear();
        }
    }
}
