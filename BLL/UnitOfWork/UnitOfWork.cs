



using BLL.Repositoories;
using CORE.DAL;
using Microsoft.AspNetCore.Identity;


namespace BLL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MyContext context;
        public UnitOfWork(MyContext _context)
        {
            context = _context;
        }

        private IRepository<Products> Products;
        public IRepository<Products> _Products
        {
            get { return Products ?? (Products = new Respository<Products>(context)); }
        }


        private IRepository<Categories> Categories;
        public IRepository<Categories> _Categories
        {
            get { return Categories ?? (Categories = new Respository<Categories>(context)); }
        }

        private IRepository<IdentityUser> User;
        public IRepository<IdentityUser> _User
        {
            get { return User ?? (User = new Respository<IdentityUser>(context)); }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
            System.GC.SuppressFinalize(this);
        }
    }
}
