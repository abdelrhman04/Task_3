
using BLL.Repositoories;
using CORE.DAL;
using Microsoft.AspNetCore.Identity;
namespace BLL;
public interface IUnitOfWork
{

    IRepository<Products> _Products { get; }
    IRepository<Categories> _Categories { get; }
    IRepository<IdentityUser> _User { get; }  
    void Save();
}

