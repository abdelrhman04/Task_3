using BLL.Services;
using CORE.DAL;
using CORE.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Task_3.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService CategoryService;

        public CategoryController(ICategoryService CategoryService)
        {
            this.CategoryService = CategoryService;
        }
        public async Task< IActionResult> Index()
        {
            ViewBag.Category = await CategoryService.GetAll(null);
            return View();
        }
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
         public async Task<IActionResult> Add(CategoryModel Item)
        {
            var result = await CategoryService.Add(new Categories
            {
                
                Name = Item.Name,
            });
            return RedirectToAction("Index");
        }
    }
}
