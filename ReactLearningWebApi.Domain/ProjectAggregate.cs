namespace ReactLearningWebApi.Domain
{
    public class ProjectAggregate
    {
        private readonly IRepository<ProjectEntity> projectRepository;

        public ProjectAggregate(IRepository<ProjectEntity> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public void AddProject(ProjectEntity projectEnt)
        {
            projectRepository.SaveAsync(projectEnt);
        }
    }
}