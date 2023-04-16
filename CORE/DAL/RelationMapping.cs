using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL
{
    public static class RelationMapping
    {
        public static void MappRelationships(this ModelBuilder builder)
        {
            builder.Entity<Products>().
          HasOne(i => i.Category)
          .WithMany(i => i.Products)
          .HasForeignKey(i => i.CategoryId)
          .IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Categories>()
        .HasOne(c => c.ParentCategory)
        .WithMany(c => c.ChildCategories)
        .HasForeignKey(c => c.ParentCategoryId).OnDelete(DeleteBehavior.SetNull);

        }
    }
}
