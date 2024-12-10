using MODEL.Entities;

namespace MVC.Areas.Dashboard.Models
{
    public class CategoryViewModel
    {
        public List<Category> ActiveCategories { get; set; }
        public List<Category> PassiveCategories { get; set; }
       

    }
}
