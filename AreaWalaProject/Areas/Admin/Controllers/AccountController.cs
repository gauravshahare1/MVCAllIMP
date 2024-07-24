using AreaWalaProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Text.Json;

namespace AreaWalaProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Site"] = "GHaash Technology";
            ViewBag.welcome = "Good Morning";
            TempData["commonData"] = "Common Data for All Views";
            return View();
        }

        [HttpGet] 
        public IActionResult Login()
        {
            TempData["commonData"] = "Common Data for All Views";
            return View();
        }

        [HttpPost]
        //public IActionResult Login(LoginModel user)
        public IActionResult Login(IFormCollection form)
        {
            string loginAs = form["LogInAs"];
            string site = form["website"]; // hidden

            LoginModel user = new LoginModel()
            { 
            userName= form["userName"],
            Password= form["Password"]
            
            };

            //  TempData["commonData"] = "Common Data After Login";

            TempData["user"]= JsonSerializer.Serialize(user);

            Response.Cookies.Append("DemoUsername", user.userName);

            string userDetails = JsonSerializer.Serialize(user);
            Response.Cookies.Append("DemouserDetails", userDetails, 
                new CookieOptions() {Expires = DateTime.Now.AddDays(1) });


            HttpContext.Session.SetString("sessionUName", "Ghassh");


            if (user.userName == "user" &&
                user.Password == "user")
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            return View();
        }
        [HttpGet]
        public IActionResult Welcome(int? id, string name, int? age)
        {
            //to read query parameters
            string userName = Request.Query["name"];
            int userAge = int.Parse(Request.Query["age"]);

            string value = "Nikhil&Kajal";
            string enValue= HttpUtility.UrlEncode(value); // 

            ViewBag.name=name;
            ViewBag.age=age;
            return View();
        }
    }
}
