using Microsoft.AspNetCore.Mvc;
using Vcart.Services.Interface;

namespace VCartWeb.Controllers
{
    public class CategoriesController : Controller
    {
        ICateogoryService _cateogoryService;

        public CategoriesController(ICateogoryService cateogoryService)
        {
            _cateogoryService = cateogoryService;
        }

        public IActionResult Index()
        {
            return View(_cateogoryService.GetAll());
        }
    }
}
