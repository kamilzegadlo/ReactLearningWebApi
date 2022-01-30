using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReactLearningWebApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactLearningWebApi.Repositories
{
    [Injectable]
    public class DBContextFactory :IDBContextFactory
    {
        private readonly IConfiguration configuration;

        public DBContextFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbAppRepositoryContext Get()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbAppRepositoryContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new DbAppRepositoryContext(optionsBuilder.Options);
        }
    }
}
