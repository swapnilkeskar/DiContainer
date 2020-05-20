namespace Depedencies.DiContainer_poc
{
    using System;

    public class ServiceDescriptor
    {
        //Get the type information
        public Type ServiceType { get; set; }

        //
        public object ServiceImplementation { get; set; }

        public ServiceLifeTime lifeTime {get;set;}

        public ServiceDescriptor(object serviceImplementation, ServiceLifeTime lifetime)
        {
            ServiceType = serviceImplementation.GetType();
            ServiceImplementation = serviceImplementation;
            lifeTime = lifetime;
        }
    }

    public enum ServiceLifeTime
    {
        Singleton,
        Transient
    }
}
