using ReactLearningWebApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactLearningWebApi.Domain
{
    public class ProjectEntity : IStoreable
    {
        public ProjectEntity(IComparable id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public ProjectEntity(string name, string description)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public IComparable Id { get; private set; }

        public object Clone()
        {
            return new ProjectEntity(Id, Name, Description);
        }
    }
}
