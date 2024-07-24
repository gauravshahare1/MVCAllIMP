using Microsoft.AspNetCore.Mvc;

namespace ASPMVC2.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string GetMessage()
        {
            return "Hello, Ajmal";
        }
    }
}
