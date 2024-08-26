using EFDAL;
using EFDAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFDALMVCClient.Controllers
{
    public class ProductsController : Controller
    {
        FlipkartContext _db;

        public ProductsController(FlipkartContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var catogories = _db.Products.ToList();
            return View(catogories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product  product)
        {
            try
            {
                _db.Products.Add(product);
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
                Product cat = _db.Products.Find(id);
                _db.Products.Remove(cat);
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
           Product cat = _db.Products.Find(Id);
            return View(cat);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
          Product cat = _db.Products.Find(Id);
            return View(cat);
        }

        //[HttpPost]
        //public IActionResult Edit(Category category)
        //{
        //    Product cat = _db.Products.Find(category.CategoryId);
        //    cat.Name = category.Name;
        //    cat.Description = category.Description;
        //    return View(cat);
        //}
    }
}
