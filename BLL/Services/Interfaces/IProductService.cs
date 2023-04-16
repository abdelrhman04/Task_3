using CORE.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IProductService
    {
        Task<IEnumerable<SelectListItem>> GetAllCategory();
        Task<List<Products>> GetAll();
        Task<Products> GetById(int id);
        Task<Products> Add(Products product);
        Task<Products> Update(Products product);
        Task<Products> Delete(int id);
    }
}
