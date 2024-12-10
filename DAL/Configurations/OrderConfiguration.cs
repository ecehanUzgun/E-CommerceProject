using DAL.Data.FakeData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //Sipariş adresi 500 karakter olmalı.
            builder.Property(x => x.ShippedAddress).HasMaxLength(500);

            //Sipariş tarih boş geçilir olmalı.
            builder.Property(x => x.ShippedDate).IsRequired(false);

            //Fake Data
            builder.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);
            //builder.HasData(OrderFakeData.Orders);
        }
    }
}
