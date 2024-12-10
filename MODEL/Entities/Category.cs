using MODEL.Abstracts;
using MODEL.Concretes;
using MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class Category :BaseEntity
    {
        //Sadece kategoriye ait özellikler
        public string CategoryName { get; set; }
        public string Description { get; set; }

        //Mapping (İlişkiler) 1-n
        public virtual List<Product> Product { get; set;}
    }
}
