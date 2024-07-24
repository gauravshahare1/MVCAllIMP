using ASPMVC3.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPMVC3.Controllers
{
    public class UserController : Controller
    {
        public ViewResult User()
        {
            // hit database to fetch all user
            List<UserModel> users = new List<UserModel>()
            {
               new UserModel() {Name="Vishal",Email="v@v.com"},
               new UserModel() {Name="Mahesh",Email="m@m.com"},
               new UserModel() {Name="Vivek",Email="v@v.com"},
               new UserModel() {Name="Rajesh",Email="r@r.com"},
               new UserModel() {Name="Ajmal",Email="a@a.com"}
            };

            ViewBag.Name = "Ghaash Technology";
            ViewData["email"] = "ghaash@gmail.com";

            //ViewBag.Users= users;

           // ViewData["Users"] = users;

            return View(users);
        }

        public IActionResult Details()
        {
            UserModel user = new UserModel() { Name="Rajat", Email="Rajat@gmail.com"};
            return View(user);
        }
    }
}
