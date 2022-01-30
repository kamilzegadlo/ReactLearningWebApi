using Microsoft.EntityFrameworkCore;
using ReactLearningWebApi.Core;
using ReactLearningWebApi.Domain;
using ReactLearningWebApi.Repositories;
using System.Reflection;

namespace ReactLearningWebApi
{
    public static class DIInstaller
    {
        public static IServiceProvider RegisterServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<DbAppRepositoryContext>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection", b => b.MigrationsAssembly("ReactLearningWebApi.Repositories")));

            services.AddServicesFromAssemblies();

            return services.BuildServiceProvider();
        }

        public static void AddServicesFromAssemblies(this IServiceCollection services)
        {
            String path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] fis = di.GetFiles("*.dll");
            foreach (FileInfo fi in fis)
            {
                var assembly = Assembly.LoadFrom(fi.FullName);

                var injectableTypes = assembly.DefinedTypes
                .Where(x => x.GetCustomAttributes(typeof(InjectableAttribute), false).FirstOrDefault() != null && x.IsClass);

                foreach (var injectableType in injectableTypes)
                {
                    var injectAttributeData = injectableType
                        .GetCustomAttributes(typeof(InjectableAttribute), false).First() as InjectableAttribute;
          
                    foreach (var implementedInterface in injectableType.ImplementedInterfaces)
                    {
                        services.Add(new ServiceDescriptor(
                            implementedInterface,
                            injectableType,
                            injectAttributeData.ServiceLifetime));
                    }
                }
            }
        }
    }
}
