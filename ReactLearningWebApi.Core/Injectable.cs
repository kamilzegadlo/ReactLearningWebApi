using Microsoft.Extensions.DependencyInjection;

namespace ReactLearningWebApi.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InjectableAttribute : Attribute
    {
        public ServiceLifetime ServiceLifetime { get; }

        public InjectableAttribute(ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        {
            ServiceLifetime = serviceLifetime;
        }
    }
}