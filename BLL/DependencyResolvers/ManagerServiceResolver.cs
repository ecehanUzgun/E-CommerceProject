using BLL.Services.Abstracts;
using BLL.Services.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DependencyResolvers
{
    public static class ManagerServiceResolver
    {
        public static void AddManagerServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceManager<>), typeof(ServiceManager<>));
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IProductService,ProductService>();
        }
    }
}
