using Microsoft.AspNetCore.Mvc;

namespace ASPMVC3.Controllers
{
    public class AccountController : Controller
    {
       
       public IActionResult Display()
        {
            return View("Razor");
        }











       
        public IActionResult Index(int a)
        {
            return View(a);
        }


        [Route(" ")]
        [Route("Swinal")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}
