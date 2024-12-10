
using Microsoft.AspNetCore.Identity;
using MODEL.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class User:IdentityUser<int>
    {
        public string Address { get; set; }

        // Relational properties
        // 1 order -> 1 user // 1 user -> n order
        public virtual List<Order> Orders { get; set; }
    }
}
