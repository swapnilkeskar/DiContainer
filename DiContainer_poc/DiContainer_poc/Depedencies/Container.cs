namespace Depedencies.DiContainer_poc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Container
    {
        private List<ServiceDescriptor> _serviceDes;

        public Container(List<ServiceDescriptor> serviceDes)
        {
            _serviceDes = serviceDes;
        }


        public T GetService<T>()
        {
            return GetService<T>(typeof(T));
        }

        public T GetService<T>(Type serviceType)
        {
            var descriptor = _serviceDes.SingleOrDefault(x => x.ServiceType == serviceType);

            if(descriptor == null)
            {
                throw new Exception ($"Service is not registered for {typeof(T).Name}");
            }

            if (descriptor.ServiceImplementation != null && descriptor.LifeTime == ServiceLifeTime.Singleton)
            {
                return (T)descriptor.ServiceImplementation;
            }

            var implementaion = (T)Activator.CreateInstance(descriptor.ServiceType);

            if (descriptor.LifeTime == ServiceLifeTime.Singleton)
            {
                descriptor.ServiceImplementation = implementaion;
            }
            
            return implementaion;
        }
    }
}