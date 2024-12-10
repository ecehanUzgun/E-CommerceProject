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
    internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            //Id veritabanına gönderilirken engellenecek.
            builder.Ignore(x => x.ID);

            //OrderId ve ProductId Composite key olarak tanımlanacak.
            builder.HasKey(x => new {x.OrderId, x.ProductId});

            builder.Property(x => x.UnitPrice).HasColumnType("money");

            //Fake Data
            //builder.HasData(OrderDetailFakeData.OrderDetails);
        }
    }
}
