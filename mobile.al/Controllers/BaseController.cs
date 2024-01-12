using Microsoft.AspNetCore.Mvc;

namespace mobile.al.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
