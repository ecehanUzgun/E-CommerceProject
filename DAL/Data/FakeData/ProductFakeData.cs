using Bogus;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.FakeData
{
    public class ProductFakeData
    {
        //public static List<Product> Products = new List<Product>
        //{
        //    new Product{ID=1, ProductName="Chai", UnitPrice=10, UnitsInStock=39, CategoryId=1},
        //    new Product{ID=2, ProductName="Chang", UnitPrice=19, UnitsInStock=17, CategoryId = 1}
        //};

        public static List<Product> GetFakeProducts()
        {
            Faker faker= new Faker();

            //10 adet kategori için 10'ar adet ürün oluşturun.
            List<Product> products = new List<Product>();
            for (int i = 1; i <= 10; i++)//10 adet kategori için
            {
                for (int j = 1; j <= 10; j++)
                {
                    Product product = new Product();
                    product.ID = (i - 1) * 10 + j;
                    product.ProductName = faker.Commerce.Product();
                    product.Description = faker.Commerce.ProductDescription();
                    product.UnitPrice = Convert.ToDecimal(faker.Commerce.Price(1, 1000, 2));
                    product.UnitsInStock = (short)faker.Random.Number(1, 100);
                    product.ImageURL = faker.Image.PlaceholderUrl(500, 500);
                    product.CategoryId = i;
                    products.Add(product);
                }
            }





            return products;
        }
    }
}
