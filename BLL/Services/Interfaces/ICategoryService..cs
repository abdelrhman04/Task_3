using CORE.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<SelectListItem>> GetAllCategory();
        Task<List<Categories>> GetChildCategories(int? parentId);
        Task<List<Categories>> GetAll();
        Task<Categories> GetById(int id);
        Task<Categories> Add(Categories category);
        Task<Categories> Update(Categories category);
        Task Delete(int id);
    }
}
