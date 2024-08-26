using EFDAL;
using EFDAL.Entities;
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            try
            {
                _db.Categories.Add(category);
                _db.SaveChanges(); //reflect chages to DB
                return RedirectToAction("Index");
                
            }
            catch 
            {
                ModelState.AddModelError("Name", "Error in adding Category");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
               Category cat= _db.Categories.Find(id);
                _db.Categories.Remove(cat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {

            }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int Id)
        {
            Category cat = _db.Categories.Find(Id);
            return View(cat);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Category cat = _db.Categories.Find(Id);
            return View(cat);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            Category cat = _db.Categories.Find(category.CategoryId);
            cat.Name = category.Name;
            cat.Description = category.Description;
            return View(cat);
        }
    }
}
