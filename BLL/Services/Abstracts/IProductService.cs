using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstracts
{
    public interface IProductService :IServiceManager<Product>
    {
        //10'ar adet ürün teslim eden metot
        public List<Product> GetProductLimit();
    }
}
