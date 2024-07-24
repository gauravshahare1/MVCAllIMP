using Microsoft.AspNetCore.Mvc;

namespace ASPMVC3.Controllers
{
 
    public class DepartmentController : Controller
    {
        //[Route("")]
       public string Welcome()
        {
            return "Welcome to G#";
        }

        string Private()
        {
            return "Private Access";
        }
        //[NonAction]
        //[Route("{id?}/{Swinal}")]
       public string Public()
        {
            return "Public Access";
        }

        //[Route("Ajmal")]
        public List<string> Cities()
        {
            return new List<string>
            {
                "Pune", "Nagpur", "Banglore","Bhiar"
            };
        }
    }
}
