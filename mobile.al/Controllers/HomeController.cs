using Microsoft.AspNetCore.Mvc;

namespace mobile.al.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
