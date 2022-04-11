using Microsoft.AspNetCore.Mvc;

namespace Project2.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error(string message)
        {
            return View("Error",message);
        }
    }
}
