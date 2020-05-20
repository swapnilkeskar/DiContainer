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
            var descriptor = _serviceDes.SingleOrDefault(x => x.ServiceType == typeof(T));

            if(descriptor == null)
            {
                throw new Exception ($"Service is not registered for {typeof(T).Name}");
            }

            if (descriptor.lifeTime == ServiceLifeTime.Transient)
            {
                return (T)Activator.CreateInstance(descriptor.ServiceType);                
            }
            
            return (T)descriptor.ServiceImplementation;
        }
    }
}