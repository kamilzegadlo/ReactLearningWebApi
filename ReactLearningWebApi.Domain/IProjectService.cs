using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactLearningWebApi.Domain
{
    public interface IProjectService
    {
        Task AddProjectAsync(ProjectEntity projectEnt);
    }
}
