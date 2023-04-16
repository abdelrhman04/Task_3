using CORE.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IUserService
    {
        public Task<APIResponse> SignInCustomer(LoginModel model);
        public Task<APIResponse> CreateCustomer(ResigterModel obj);
    }
}
