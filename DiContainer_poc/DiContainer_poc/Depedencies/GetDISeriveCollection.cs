namespace Depedencies.DiContainer_poc
{
    using System.Collections.Generic;
    public class GetDISeriveCollection
    {
        public GetDISeriveCollection()
        {
        }

        private List<ServiceDescriptor> _serviceDes = new List<ServiceDescriptor>();
        
        //Add Singleton object
        public void AddSingleton<TService>(TService serviceImplemenation)
        {
            _serviceDes.Add(new ServiceDescriptor(serviceImplemenation, ServiceLifeTime.Singleton));
        }

        public void AddSingleton<TService>()
        {
            _serviceDes.Add(new ServiceDescriptor(typeof(TService), ServiceLifeTime.Singleton));
        }


        //Add Trasnsient object
        public void AddTransient<TService>(TService serviceImplemenation)
        {
            _serviceDes.Add(new ServiceDescriptor(serviceImplemenation, ServiceLifeTime.Transient));
        }

        public void AddTransient<TService>()
        {
            _serviceDes.Add(new ServiceDescriptor(typeof(TService), ServiceLifeTime.Transient));
        }


        public Container BuildContainer()
        {
            return new Container(_serviceDes);
        }

        public void Clear()
        {
            _serviceDes.Clear();
        }
    }
}