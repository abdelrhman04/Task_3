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
            ViewBag.Category = await CategoryService.GetAll();
            return View();
        }
        public async Task<IActionResult> Add()
        {
            ViewBag.Category = await CategoryService.GetAllCategory();
            return View();
        }
        [HttpPost]
         public async Task<IActionResult> Add(CategoryModel Item)
        {
            var result = await CategoryService.Add(new Categories
            {
                ParentCategoryId=Item.CategoryId,
                Name = Item.Name,
            });
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Reusion()
        {
            ViewBag.Category = await CategoryService.GetChildCategories(null);
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
             await CategoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
