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
    public class CategoryService : ServiceManager<Category>, ICategoryService
    {
        public CategoryService(IRepository<Category> repository) : base(repository)
        {
           
        }
    }
}
