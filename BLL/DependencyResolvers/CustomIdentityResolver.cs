using DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MODEL.Entities;

namespace BLL.DependencyResolvers
{
    public static class CustomIdentityResolver
    {
        public static void AddCustomIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<int>>(x =>
            {
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireDigit = false;
                x.Password.RequiredLength = 3;
                x.Password.RequireUppercase = false;
                x.Password.RequireLowercase = false;
                //x.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ProjectContext>()
            .AddDefaultTokenProviders(); // Şifre sıfırlama, iki faktörlü kimlik doğrulama, e-posta onayı
        }
    }
}
