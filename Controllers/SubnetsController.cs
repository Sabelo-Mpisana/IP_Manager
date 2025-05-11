using Microsoft.AspNetCore.Mvc;

namespace IP_Manager.Controllers
{
    public class SubnetsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
