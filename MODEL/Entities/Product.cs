using MODEL.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class Product:BaseEntity
    {
        
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        //Relational Properties
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        //1 product  n order   // 1 order n product
        public virtual List<OrderDetail> OrderDetail { get; set; }
    }
}
