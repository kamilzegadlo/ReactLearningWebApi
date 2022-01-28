using Microsoft.EntityFrameworkCore;
using ReactLearningWebApi.Domain;

namespace ReactLearningWebApi.Repositories
{
    public class ProjectRepository : IRepository<ProjectEntity>
    {
        private DbAppRepositoryContext context { get; }
        private readonly DbSet<Project> dbSet;

        public ProjectRepository(DbAppRepositoryContext context)
        {
            this.context = context;
            dbSet = context.Set<Project>();
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

        private async Task<Project> FindDbEntityById(IComparable id)
        {
            return await dbSet.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task SaveAsync(ProjectEntity item)
        {
            var p = await FindDbEntityById(item.Id);

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