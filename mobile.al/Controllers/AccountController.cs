using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mobile.al.Models.Chat;

namespace mobile.al.Controllers
{
    public class AccountController : Controller
    {
        private IUser _UserRepo;
        public AccountController(IUser UserRepo)
        {
            this._UserRepo = UserRepo;
        }
        [HttpGet]
        public ActionResult Login()
        {
            if (MySession.Current.UserID > 0)
            {
                return RedirectToAction("Chat", "User");
            }
            UserModel objmodel = new UserModel();
            return View(objmodel);
        }
        [HttpPost]
        public ActionResult Login(UserModel objmodel) 
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
