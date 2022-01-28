using Microsoft.AspNetCore.Mvc;

namespace ReactLearningWebApi.Controllers
{
    [ApiController]
    [Route("api/project")]
    public class ProjectController : Controller
    {
        [HttpPost]
        public IActionResult AddProject()
        {
            return View();
        }
    }
}
