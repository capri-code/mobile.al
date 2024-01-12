using Microsoft.AspNetCore.Mvc;

namespace mobile.al.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
