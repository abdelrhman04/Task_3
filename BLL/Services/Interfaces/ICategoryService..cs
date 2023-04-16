using CORE.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ICategoryService
    {
        Task<List<Categories>> GetAll(int? Category_Id);
        Task<Categories> GetById(int id);
        Task<Categories> Add(Categories category);
        Task<Categories> Update(Categories category);
        Task<Categories> Delete(int id);
    }
}
