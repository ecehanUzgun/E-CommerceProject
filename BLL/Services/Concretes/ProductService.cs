using BLL.Services.Abstracts;
using DAL.Repository.Abstracts;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concretes
{
    public class ProductService:ServiceManager<Product> ,IProductService
    {
        public ProductService(IRepository<Product> repository) : base(repository)
        {

        }

        //todo: Ege'nin merak etmiş olduğu belli sayıda ürünün teslim edileceği metot.
        public List<Product> GetProductLimit()
        {
            throw new NotImplementedException();
        }
    }
}
