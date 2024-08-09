using EFDAL;
using Microsoft.AspNetCore.Mvc;

namespace EFDALMVCClient.Controllers
{
    public class CategoriesController : Controller
    {
        FlipkartContext _db;

        public CategoriesController(FlipkartContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var catogories = _db.Categories.ToList();
            return View(catogories);
        }
    }
}
