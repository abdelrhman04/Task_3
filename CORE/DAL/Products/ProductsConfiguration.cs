using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CORE.DAL;
public class ProductsConfiguration : IEntityTypeConfiguration<Products>
{
    public void Configure(EntityTypeBuilder<Products> builder)
    {
        builder.ToTable("Product");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(i => i.Name).IsRequired();
        builder.Property(i => i.Price).IsRequired();
        builder.Property(i => i.CategoryId).IsRequired();
    }
}

