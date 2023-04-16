using BLL.Helper;
using CORE.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork uow;
        private readonly SignInManager<IdentityUser> SignInManager;
        private readonly UserManager<IdentityUser> UserManager;
        private readonly IConfiguration _configuration;
        public UserService(IUnitOfWork uow, IConfiguration configuration, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.uow = uow;
            SignInManager = signInManager;
            UserManager = userManager;
            _configuration = configuration;
        }

        public async Task<APIResponse> CreateCustomer(ResigterModel obj)
        {
            try
            {
                var userExists = await UserManager.FindByEmailAsync(obj?.Email);
                if (userExists != null)
                {
                    return userExists.GetRespons(true, "هذا المستخدم موجود بالفعل", StatusCodes.Status500InternalServerError);
                }
                var token = Guid.NewGuid().ToString();
                IdentityUser user = new IdentityUser()
                {
                    UserName = obj.UserName,
                    Email = obj.Email,
                    PhoneNumber = obj.PhoneNumber,
                };
                var result = await UserManager.CreateAsync(user, obj?.Password);
                if (!result.Succeeded)
                {
                    return userExists.GetRespons(true, "لم يتم إنشاء مستخدم الرجاء التحقق من البيانات و المحاولة مجدداً", 400);
                }
                return userExists.GetRespons(false, "تم إنشاء المستخدم الرجاء تسجيل الدخول", 200);

            }
            catch (Exception ex)
            {
                return ex.GetRespons(true, ex.Message, StatusCodes.Status500InternalServerError);

            }
        }

        public async Task<APIResponse> SignInCustomer(LoginModel model)
        {
            try
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
            if (user != null && await UserManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await UserManager.GetRolesAsync(user);
                var userClaims = await UserManager.GetClaimsAsync(user);

                var token = user.Create_Token(userRoles, userClaims, _configuration["JWT:Key"]);
                return new APIResponse
                {
                    IsError = false,
                    Message = "تم تسجيل الدخول بنجاح",
                    Data = 
                        new JwtSecurityTokenHandler().WriteToken(token),
                       
                    Code = 200
                };
            }
            return model.GetRespons(true, "الرجاء التأكد من البيانات", 401);
            }
            catch (Exception ex)
            {
                return ex.GetRespons(true, ex.Message, StatusCodes.Status500InternalServerError);

            }
        }
    }
}
