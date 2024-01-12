using Microsoft.AspNetCore.Mvc;

namespace mobile.al.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
