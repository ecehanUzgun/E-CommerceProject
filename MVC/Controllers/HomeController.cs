using BLL.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MODEL.Entities;
using MVC.Models;
using MVC.Models.RequestModels;
using MVC.Models.SessionService;
using MVC.Models.ShoppingTools;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService, IProductService productService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetActives();
            return View(_productService.GetActives().ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        public async Task<IActionResult> AddToCart(int id)
        {

            //Cart c;
            //if (GetCartFromSession("scart") == null)
            //{
            //    c = new Cart();
            //}
            //else
            //{
            //    c = GetCartFromSession("scart");
            //}

            Cart c = GetCartFromSession("scart") == null ? new Cart() : GetCartFromSession("scart");

            Product orijinalUrun = _productService.GetById(id);

            CartItem sepeteAtilacakUrun = new()
            {
                Id = orijinalUrun.ID,
                ProductName = orijinalUrun.ProductName,
                UnitPrice = orijinalUrun.UnitPrice,
                ImagePath = orijinalUrun.ImageURL,
                CategoryName = orijinalUrun.Category.CategoryName
               
            };

            c.AddToCart(sepeteAtilacakUrun);
            SetCartForSession(c);
            TempData["Message"] = $"{sepeteAtilacakUrun.ProductName} isimli ürün sepete eklenmiştir";
            return RedirectToAction("Index");
        }

        #region OzelSepetMetotlari
        Cart GetCartFromSession(string key)
        {
            return HttpContext.Session.GetObject<Cart>(key);
        }

        void SetCartForSession(Cart c)
        {
            HttpContext.Session.SetObject("scart", c);
        } 

        void ControlCart(Cart c)
        {
            if (c.GetCartItems.Count == 0) HttpContext.Session.Remove("scart");
        }
        #endregion


        [Authorize(Roles = "Member")]
        public IActionResult CartPage()
        {
            if (GetCartFromSession("scart") == null)
            {
                TempData["Message"] = "Sepetiniz su anda bos...";
                return RedirectToAction("Index");
            }
            Cart c = GetCartFromSession("scart");
            return View(c);
        }

        public IActionResult DeleteFromCart(int id)
        {
            Cart c = GetCartFromSession("scart");
            c.RemoveFromCart(id);
            SetCartForSession(c);
            ControlCart(c);

            return RedirectToAction("CartPage");
        }

        public IActionResult DecreaseItem(int id)
        {
            if(GetCartFromSession("scart") != null)
            {
                Cart c = GetCartFromSession("scart");
                c.Decrease(id);
                SetCartForSession(c);
                ControlCart(c);

            }

            return RedirectToAction("CartPage");
        }

        public IActionResult IncreaseItem(int id)
        {
            Cart c = GetCartFromSession("scart");
            c.Increase(id);
            SetCartForSession(c);
            return RedirectToAction("CartPage");
        }

        [Authorize(Roles = "Member")]
        public IActionResult ConfirmOrder()
        {
            return View();
        }

        [Authorize(Roles ="Member")]
        [HttpPost]
        public async Task<IActionResult> ConfirmOrder(OrderRequestPageVM model)
        {
            
            return RedirectToAction("Index");
        }
    }
}