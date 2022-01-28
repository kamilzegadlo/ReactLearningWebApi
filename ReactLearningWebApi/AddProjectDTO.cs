using ReactLearningWebApi.Domain;

namespace ReactLearningWebApi
{
    public class AddProjectDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ProjectEntity ToProjectEntity()
        {
            return new ProjectEntity(Name, Description);
        }
    }
}
