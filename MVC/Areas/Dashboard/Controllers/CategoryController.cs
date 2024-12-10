using BLL.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MODEL.Entities;
using MVC.Areas.Dashboard.Models;

namespace MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {



            CategoryViewModel cvm = new CategoryViewModel
            {
                ActiveCategories = _categoryService.GetActives().ToList(),
                PassiveCategories = _categoryService.GetPassives().ToList()

            };

            return View(cvm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            try
            {
                await _categoryService.CreateAsync(category);

                TempData["Success"] = "Kategori Oluşturuldu";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        //todo: Delete işlemi iki adımdan meydana gelebilir. Bu adımlar silinecek olan kategorinin ayrı bir sayada gösterilmesi ve onaylandıktan sonra ilgili kategorinin kaldırılması. (GET/POST)
        public async Task<IActionResult> Delete(int id)
        {
            var deletedCategory = _categoryService.GetById(id);

            if (deletedCategory != null)
            {
                try
                {
                    await _categoryService.DeleteAsync(deletedCategory);
                    TempData["Success"] = "Kategori Kaldırıldı";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    TempData["Error"] = ex.Message;
                    return View();
                }
            }
            return View();

        }

        public IActionResult Update(int id)
        {
            var kategori = _categoryService.GetById(id);

            return View(kategori);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            _categoryService.UpdateAsync(category);
            return RedirectToAction("Index");
        
        }


    }
}
