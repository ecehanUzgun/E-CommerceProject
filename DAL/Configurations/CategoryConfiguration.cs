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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.CategoryName).HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(255);

            //Description boş geçilebilir.
            builder.Property(x => x.Description).IsRequired(false);

            //Fake Data
            builder.HasData(CategoryFakeData.GetFakeCategories());
        }
    }
}
