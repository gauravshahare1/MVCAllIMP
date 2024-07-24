using AreaWalaProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AreaWalaProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //ViewBag.CD = TempData["commonData"];
            //TempData.Keep("commonData");

            ViewBag.CD = TempData.Peek("commonData");

           ViewBag.CookieData= Request.Cookies["DemoUsername"];

            ViewBag.userDetails =JsonSerializer.Deserialize<LoginModel>(Request.Cookies["DemouserDetails"]);

           ViewBag.SessionName = HttpContext.Session.GetString("sessionUName");

            return View();
        }
    }
}
