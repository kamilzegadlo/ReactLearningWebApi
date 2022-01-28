using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactLearningWebApi.Repositories
{
    public class DbAppRepositoryContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public DbAppRepositoryContext(DbContextOptions options) : base(options)
        {

        }
    }
}
