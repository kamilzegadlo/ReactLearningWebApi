using Microsoft.EntityFrameworkCore;
using ReactLearningWebApi.Domain;
using ReactLearningWebApi.Repositories;

namespace ReactLearningWebApi
{
    public static class DIInstaller
    {
        public static IServiceProvider RegisterServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<DbAppRepositoryContext>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection", b => b.MigrationsAssembly("ReactLearningWebApi.Repositories")));

            services.AddSingleton<IDBContextFactory, DBContextFactory>();
            services.AddSingleton<IRepository<ProjectEntity>, ProjectRepository>();
            services.AddSingleton<IProjectService, ProjectService>();

            return services.BuildServiceProvider();
        }
    }
}
