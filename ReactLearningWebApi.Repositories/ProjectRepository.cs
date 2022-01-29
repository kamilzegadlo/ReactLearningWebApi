using Microsoft.EntityFrameworkCore;
using ReactLearningWebApi.Domain;

namespace ReactLearningWebApi.Repositories
{
    public class ProjectRepository : IRepository<ProjectEntity>
    {
        private readonly IDBContextFactory contextFactory;

        public ProjectRepository(IDBContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task<IEnumerable<ProjectEntity>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(IComparable id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProjectEntity> FindByIdAsync(IComparable id)
        {
            throw new NotImplementedException();
        }

        private async Task<Project> FindDbEntityById(DbSet<Project> dbSet, IComparable id)
        {
            return await dbSet.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task SaveAsync(ProjectEntity item)
        {
            var context = contextFactory.Get();
            var dbSet = context.Set<Project>();

            var p = await FindDbEntityById(dbSet, item.Id);

            if (p == null)
            {
                dbSet.Add(new Project(item));
                await context.SaveChangesAsync();
            }
            else
            {
                p.Description = item.Description;
                p.Name = item.Name;
                dbSet.Update(p);
            }
        }
    }
}