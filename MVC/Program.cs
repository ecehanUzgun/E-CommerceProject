using BLL.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache(); //Eger Session kompleks yapılarla calısmak icin Extension metodu ekleme durumuna maruz kalacaksa bu kod projenizin saglıklı calısması icin gereklidir...

builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromDays(1); //Projede kişinin bos durma süresi eger 1 günlük bir süre olursa Session otomatik olarak bosa cıksın..
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
});


//DbContext Service
builder.Services.AddDbContextService();




//Identity framework'ün kullanıcı bilgilerini ve rollerini veritabanında yönetebilmesi için Entity Framework kullanılır


//Cookie Manager: İçerisinde küçük boyutlu verileri tutan ve bu verilere sadece browserda ulaşan küçük yapılardır.

//Cookie yapılandırma: Cookie ile kimlik doğrulama bilgileri yönetme
builder.Services.AddCustomIdentityService();



//Services
builder.Services.AddRepositoryServices();



//Service Managers

builder.Services.AddManagerServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "Admin",
//    pattern: "{admin}/{controller=Home}/{ACtion=Index}/{id?}"
//    );


app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );


    endpoints.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}"
);


    //todo: Custom endpoint anlatılcak.

});

app.Run();
