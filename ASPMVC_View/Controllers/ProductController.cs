using ASPMVC_View.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPMVC_View.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index1()
        {
            return View("Demo");
        }

        public ViewResult Details()
        {
            ProductModel product = new ProductModel()
            {
                Name = "Casual Shirt",
                Price = 899,
                CategoryName="Mens Wear"
            };
            return View(product);
        }

        public ViewResult Edit(int? id)
        {
            ProductModel product = new ProductModel()
            {
                Name = "Casual Shirt",
                Price = 899,
                CategoryName = "Mens Wear"
            };
            return View(product);
        }
    }
}
