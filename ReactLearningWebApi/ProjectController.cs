using Microsoft.AspNetCore.Mvc;
using ReactLearningWebApi.Domain;
using ReactLearningWebApi.Repositories;

namespace ReactLearningWebApi
{
    [ApiController]
    [Route("api/project")]
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;

         public ProjectController(IProjectService projectService)
         {
             this.projectService = projectService;
         }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddProjectDTO dto)
        {
            await projectService.AddProjectAsync(dto.ToProjectEntity());

            return new OkResult();
        }
    }
}
