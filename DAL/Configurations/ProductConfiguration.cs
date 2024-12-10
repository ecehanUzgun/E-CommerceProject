using DAL.Data.FakeData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //ürün adı 255 karakter olmalı.
            builder.Property(x=>x.ProductName).HasMaxLength(255);
            //açıklama 500 karekter olmalı.
            builder.Property(x=>x.Description).HasMaxLength(500);
            //Görselin yolu 255 karakter olmalı.
            builder.Property(x=>x.ImageURL).HasMaxLength(255);

            //nullable
            builder.Property(x => x.ImageURL).IsRequired(false);
            builder.Property(x => x.Description).IsRequired(false);

            builder.Property(x => x.UnitPrice).HasColumnType("money");

            //Fake Data
            builder.HasData(ProductFakeData.GetFakeProducts());
        }
    }
}
