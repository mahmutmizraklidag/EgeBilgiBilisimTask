using EgeBilgiBilisimTask.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgeBilgiBilisimTask.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Image).HasMaxLength(100);
            builder.Property(x => x.ProductCode).HasMaxLength(30);
            //Burada class lar arasındaki ilişkileride belirtebiliyoruz.
            builder.HasOne(b => b.Brand).WithMany(p => p.Products).HasForeignKey(b => b.BrandId); //burada brand classı ile product clası arasında bire çok bir ilişki olacağını belirtik.1 olan kısım brand olduğu için hasone özelliğine brand i belirtik,Çok olan kısım product olacağı için bunu da withmany içerisinde belirtik.HasForeignKey de ise veritabanında oluşacak kolonlardan brandıd nin forign key olacağını belirtik.
            builder.HasOne(b => b.Category).WithMany(p => p.Products).HasForeignKey(b => b.CategoryId);
        }
    }
}
