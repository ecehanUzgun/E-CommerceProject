

using ConsoleApp1;
using MODEL.Entities;


List<Product> products = new List<Product>();   

for (int i = 1; i <= 10; i++)//10 adet kategori için
{
    for (int j = 1; j <= 10; j++)
    {
        Product product = new Product();
        product.ID = (i-1)*10+j;
        products.Add(product);
    }
}

foreach (var item in products)
{
    Console.WriteLine(item.ID);
}


string a = "w232asd";



a.CagrininMetodu();
