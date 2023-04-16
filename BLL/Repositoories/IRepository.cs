using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositoories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Expression<Func<T, bool>>? value = null);
        Task<T> Add(T category);
        Task<T> Update(T category);
        Task<T> Delete(Expression<Func<T, bool>>? value = null);
    }
}
