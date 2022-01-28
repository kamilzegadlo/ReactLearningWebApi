using ReactLearningWebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactLearningWebApi.Repositories
{
    public class Project : DBEntity
    {
        public Project(ProjectEntity p) : base(p.Id.ToString())
        {
            Name = p.Name;  
            Description = p.Description;
        }
        public Project()  
        {

        }

        public string Name { get; set; }
        public string Description { get; set; }

        public ProjectEntity ToProjectEntity()
        {
            return new ProjectEntity(Id, Name, Description);
        }
    }
}
