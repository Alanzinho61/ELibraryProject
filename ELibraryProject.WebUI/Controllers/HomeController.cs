using Microsoft.AspNetCore.Mvc;

namespace ELibraryProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
