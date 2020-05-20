namespace Depedencies.DiContainer_poc
{
    using System;

    public class ServiceDescriptor
    {
        //Get the type information
        public Type ServiceType { get; set; }

        //Implemention info
        public object ServiceImplementation { get; set; }

        public ServiceLifeTime LifeTime {get;set;}

        public ServiceDescriptor(object serviceImplementation, ServiceLifeTime lifetime)
        {
            ServiceType = serviceImplementation.GetType();
            ServiceImplementation = serviceImplementation;
            LifeTime = lifetime;
        }

        public ServiceDescriptor(Type serviceType, ServiceLifeTime lifetime)
        {
            ServiceType = serviceType;
            LifeTime = lifetime;
        }
    }

    public enum ServiceLifeTime
    {
        Singleton,
        Transient
    }
}
