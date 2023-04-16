using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL;
  public class MyContext:IdentityDbContext<IdentityUser>
  {
        public MyContext(DbContextOptions options) : base(options) { }

        //----------------------

        public DbSet<Products> Product { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                new ProductsConfiguration().Configure(modelBuilder.Entity<Products>());
                new CategoriesConfiguration().Configure(modelBuilder.Entity<Categories>());
            //-------------
            modelBuilder.MappRelationships();
                base.OnModelCreating(modelBuilder);
            }
   }

