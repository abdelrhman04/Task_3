using CORE.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        IUnitOfWork uow;
        public ProductService(IUnitOfWork _uow) => uow = _uow;
        public async Task<Products> Add(Products product)
        {
            return await uow._Products.Add(product);
        }

        public async Task<Products> Delete(int id)
        {
            return await uow._Products.Delete(c => c.Id == id);
        }

        public async Task<List<Products>> GetAll()
        {
            return await uow._Products.GetAll();
        }

        public async Task<Products> GetById(int id)
        {
            return await uow._Products.GetById(c => c.Id == id);
        }

        public async Task<Products> Update(Products product)
        {
            return await uow._Products.Update(product);
        }
        public async Task< IEnumerable<SelectListItem>> GetAllCategory()
        {
            var Categories = (await uow._Categories.GetAll()).Select(i => new SelectListItem(i.Name, i.Id.ToString()));
            return Categories;
        }

    }
}
