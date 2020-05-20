namespace DiContainer_poc
{
    using System;   
    using global::Depedencies.DiContainer_poc;

    // Proggram to write custome di container (registering and resolving the services)
    class Program
    {
        static void Main(string[] args)
        {
            var services = new GetDISeriveCollection();

            //Registers the services
            //services.AddSingleton<RandomGuidGenerator>(new RandomGuidGenerator());
            services.AddTransient<RandomGuidGenerator>(new RandomGuidGenerator());


            //build conainer from services 
            var container = services.BuildContainer();

            //Resolve the service
            var service1 = container.GetService<RandomGuidGenerator>();
            var service2 = container.GetService<RandomGuidGenerator>();

            //singleton gets unique guid for all service instance 
            Console.WriteLine(service1.UniqueGuid);
            Console.WriteLine(service2.UniqueGuid);

            Console.ReadKey();
        }
    }
}
