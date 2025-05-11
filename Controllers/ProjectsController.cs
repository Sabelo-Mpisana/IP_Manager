using Microsoft.AspNetCore.Mvc;

namespace IP_Manager.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
