using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactLearningWebApi.Domain
{
    public  class ProjectService : IProjectService
    {
        private readonly IRepository<ProjectEntity> projectRepository;

        public ProjectService(IRepository<ProjectEntity> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task AddProjectAsync(ProjectEntity projectEnt)
        {
            await projectRepository.SaveAsync(projectEnt);
        }
    }
}
