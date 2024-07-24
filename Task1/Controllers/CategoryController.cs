using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Task1.Data;
using Task1.Models;

namespace Task1.Controllers
{
    public class CategoryController : Controller
    {
        IConfiguration _configuration;


        public CategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
           
        }
        public IActionResult Index()
        {
            CategoryDB db = new CategoryDB(_configuration);
            var cate = db.Categories();
            return View(cate);
        }

        public IActionResult ProductByCategory(int? id)
        {
            CategoryDB db = new CategoryDB(_configuration);
            List<ProductModel> products = db.ProductByCategory(id);
            
            
            return View(products);
        }
    }
}
