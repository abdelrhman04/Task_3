using BLL;
using BLL.Services;
using CORE.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Task_3.Controllers
{
    public class UserController : Controller
    {
        IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Login([FromBody] LoginModel model)
        {
        var result= await UserService.SignInCustomer(model);
          return  Ok(result.Data);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(ResigterModel resigter)
        {
            var result = await UserService.CreateCustomer(resigter);
            return RedirectToAction("Index", "Home");
        }
    }
}
