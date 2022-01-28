using Microsoft.AspNetCore.Mvc;

namespace ReactLearningWebApi
{
    [ApiController]
    [Route("api/project")]
    public class ProjectController : Controller
    {
        [HttpPost]
        public IActionResult Add(AddProjectDTO dto)
        {
            return new OkResult();
        }
    }
}
