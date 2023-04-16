using CORE.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService : ICategoryService
    {
        IUnitOfWork uow;
        public CategoryService(IUnitOfWork _uow) => uow = _uow; 
        public async Task<Categories> Add(Categories category)
        {
            return await uow._Categories.Add(category);
        }

        public async Task<Categories> Delete(int id)
        {
            return await uow._Categories.Delete(c => c.Id == id);
        }

        public async Task<List<Categories>> GetAll(int? Category_Id)
        {
            var childCategories = new List<Categories>();

            if (Category_Id == null)
            {
               
                foreach (var category in await uow._Categories.GetAll())
                {

                    childCategories = await GetAll(category.Id);
                }
            }
            else
            {
                childCategories.Add(await uow._Categories.GetById(x => x.Id == Category_Id));
            }
            
            return childCategories;
        }
          
        

        public async Task<Categories> GetById(int id)
        {
            return await uow._Categories.GetById(c => c.Id == id);
        }

        public async Task<Categories> Update(Categories category)
        {
            return await uow._Categories.Update(category);
        }
    }
}
