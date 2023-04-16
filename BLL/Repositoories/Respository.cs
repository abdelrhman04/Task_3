using CORE.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Repositoories
{
    public class Respository<T> : IRepository<T> where T : class
    {
        private readonly MyContext _context;
        private DbSet<T> dbSet;

        public Respository(MyContext context)
        {
            _context = context;
            this.dbSet = context.Set<T>();
        }
        public async Task<T> Add(T category)
        {
            await _context.Set<T>().AddAsync(category,new CancellationToken());
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<T> Delete(Expression<Func<T, bool>>? value )
        {
            var category = await _context.Set<T>().FirstOrDefaultAsync(value);
            if (category != null)
            {
                _context.Set<T>().Remove(category);
                 await _context.SaveChangesAsync();
            }
            return category;
        }

        public async Task<List<T>> GetAll(Expression<Func<T, object>>? includes = null)
        {
            if(includes != null)
            {
                return await _context.Set<T>().Include(includes).ToListAsync(new CancellationToken());
            }
            return await _context.Set<T>().ToListAsync(new CancellationToken());
        }

        public async Task<T> GetById(Expression<Func<T, bool>>? value = null)
        {
            var category = await _context.Set<T>().FirstOrDefaultAsync(value);
            return category;
        }

        public async Task<T> Update(T category)
        {
            _context.Set<T>().Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
