using Microsoft.AspNetCore.Mvc;

namespace AreaWalaProject.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.CD = TempData["commonData"];
            return View();
        }
    }
}
