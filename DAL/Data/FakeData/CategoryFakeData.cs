using Bogus;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.FakeData
{
    public class CategoryFakeData
    {
        //public static List<Category> Categories = new List<Category>
        //{
        //    new Category{ID=1, CategoryName="Beverages", Description="Soft drinks, coffees, teas, beers, and ales"},
        //    new Category{ID=2, CategoryName="Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings"},
        //    new Category{ID=3, CategoryName="Confections", Description = "Desserts, candies, and sweet breads"},
        //    new Category{ID=4, CategoryName="Dairy Products", Description = "Cheeses"},
        //    new Category{ID=5, CategoryName="Grains/Cereals", Description = "Breads, crackers, pasta, and cereal"},
        //    new Category{ID=6, CategoryName="Meat/Poultry", Description = "Prepared meats"},
        //    new Category{ID=7, CategoryName="Produce", Description = "Dried fruit and bean curd"},
        //    new Category{ID=8, CategoryName="Seafood", Description = "Seaweed and fish"}
        //};

        public static List<Category> GetFakeCategories()
        {
            var faker = new Faker();

           List<Category> categories = new List<Category>();

            //10 adet kategori oluşturulacak.

            for (int i = 0; i < 10; i++)
            {
                Category category = new Category();

                category.MasterID=Guid.NewGuid().ToString();
                category.ID = i + 1;
                category.CategoryName= faker.Commerce.Categories(1)[0];
                category.Description = faker.Lorem.Word();
                //eğer adı aynı olan bir kategori varsa döngü tekrar edilsin.

                if (categories.Any(x => x.CategoryName == category.CategoryName))
                {
                    i--;
                    continue;
                }
                categories.Add(category);








            }

            return categories;

        }
    }
}
