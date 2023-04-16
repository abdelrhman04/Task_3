using Microsoft.AspNetCore.Hosting.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helper
{
    public static class ResponGenerator
    {
        public static APIResponse GetRespons<T>(this T response, bool iserror=false,string Message="", int code=404)
        {
            return new APIResponse
            {
                Code = code,
                IsError=iserror,
                Message=Message,
                Data=code is not 200?null: response,
            };
        }
        public static APIResponse GetResponsAll<T>(this List<T> response, bool iserror = false, string Message = "", object data= null, int code = 404)
        {
            return new APIResponse
            {
                Code = code,
                IsError = iserror,
                Message = Message,
                Data = data,
            };
        }
    }
}
