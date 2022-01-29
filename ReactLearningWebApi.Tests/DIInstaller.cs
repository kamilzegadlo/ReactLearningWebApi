using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.EntityFrameworkCore;
using ReactLearningWebApi.Repositories;
using FakeItEasy;

namespace ReactLearningWebApi.Tests
{
    internal class DIInstaller
    {
        public DbAppRepositoryContext dbContext;

        public IServiceCollection Services()
        {
            var services = new ServiceCollection();

            ReactLearningWebApi.DIInstaller.RegisterServices(services);
            services.AddTransient<ProjectController>();

            return services;
        }

        public void DoubleDatabase(IServiceCollection services)
        {
            var options = new DbContextOptionsBuilder<DbAppRepositoryContext>()
                 .UseInMemoryDatabase("InMemoryDb")
                 .Options;
            dbContext = new DbAppRepositoryContext(options);
            var contextFactory = A.Fake<IDBContextFactory>();
            A.CallTo(() => contextFactory.Get()).Returns(dbContext);

            var descriptor =
                new ServiceDescriptor(
                    typeof(IDBContextFactory),
                    contextFactory);
            services.Replace(descriptor);
        }
    }
}
