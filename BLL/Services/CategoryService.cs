using CORE.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task Delete(int id)
        {

            
            foreach (var category in (await uow._Categories.GetAll(x => x.ChildCategories)).Where(c => c.ParentCategoryId == id || c.Id==id))
            {
               
                if(category.ChildCategories != null)
                {
                    foreach (var Childcategory in category.ChildCategories)
                    {
                        await Delete(Childcategory.Id);
                    }
                    

                }
                //childCategories.Add(category);
                await uow._Categories.Delete(c => c.Id == category.Id);
            }
           

           // return await uow._Categories.Delete(c => c.Id == id || c.ParentCategoryId == id);
        }
        public async Task<List<Categories>> GetAll()
        {
            return await uow._Categories.GetAll();
        }
        public async Task< List<Categories>> GetChildCategories(int? parentId)
        {
            var childCategories = new List<Categories>();
            foreach (var category in (await uow._Categories.GetAll(x => x.ChildCategories)).Where(c => c.ParentCategoryId == parentId))
            {
                category.ChildCategories =await GetChildCategories(category.Id);
                childCategories.Add(category);
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
        public async Task<IEnumerable<SelectListItem>> GetAllCategory()
        {
            var Categories = (await uow._Categories.GetAll()).Select(i => new SelectListItem(i.Name, i.Id.ToString()));
            return Categories;
        }
    }
}
