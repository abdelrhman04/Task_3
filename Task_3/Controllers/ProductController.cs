using BLL.Services;
using CORE.DAL;
using CORE.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Task_3.Controllers
{
    public class ProductController : Controller
    {
        
            IProductService ProductService;
        ICategoryService CategoryService;
        

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            ProductService = productService;
            CategoryService = categoryService;
        }

        public async Task< IActionResult> Index()
        {
            ViewBag.Products = await ProductService.GetAll();
            return View();
        }
        public async Task<IActionResult> Add()
        {
            ViewBag.Category = await CategoryService.GetAllCategory();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductModel Item)
        {
            var result = await ProductService.Add(new Products
            {
             CategoryId= Item.CategoryId,
                Name = Item.Name,
                Price= Item.Price,
            });
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await ProductService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
