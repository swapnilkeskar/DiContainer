namespace Depedencies.DiContainer_poc
{
    using System;
    public  class RandomGuidGenerator
    {
        public Guid UniqueGuid { get; set; } = Guid.NewGuid();
    }
}