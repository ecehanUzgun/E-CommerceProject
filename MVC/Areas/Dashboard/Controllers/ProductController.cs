using BLL.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MODEL.Entities;
using MVC.Utils;

namespace MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]

    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        private readonly ICategoryService _categoryServie;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryServie = categoryService;
        }


        public IActionResult Index()
        {

            return View(_productService.GetAll().ToList());
        }
       
        
        [HttpGet]
            public async Task<IActionResult> Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile productImage)//IFormFile From etiketi içerisinde kullanıcı tarafından eklenen herhangi bir dosyayı bünyesinde barındırmak için kullandığımız bir interface'dir.
        {
            try
            {

                //Image/Product/Tech/Laptop

                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\products");
               string uploadResult= ImageUploader.UploadImage(productImage, uploadPath);

                if (uploadResult != null)
                {
                    product.ImageURL = uploadResult;
                    //todo: CAtegory Id geçici olarak tanımlandı.
                    product.CategoryId = 1;
                }

                await _productService.CreateAsync(product);
                TempData["Success"] = "Kategori Oluşturuldu";
                return RedirectToAction("Index");
            }
            catch (Exception ex )
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }


       
       

    }
}
