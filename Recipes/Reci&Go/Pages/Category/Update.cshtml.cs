using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reci_Go.Models;
using Reci_Go.Services.Implementations;
using Reci_Go.Services.Interface;

namespace Reci_Go.Pages.Category
{
    public class UpdateModel : PageModel
    {
        private readonly IServiceGeneric<Categories> _categoryService;

        public UpdateModel(IServiceGeneric<Categories> categoriesService)
        {
            _categoryService = categoriesService;
        }
        public Categories Category { get; set; }

        public void OnGet(int id)
        {
            Category = _categoryService.GetById(id);
        }

        public IActionResult OnPost()
        {
            Categories category = new Categories();
            category.Id = Convert.ToInt32(Request.Form["id"]);
            category.Name = Convert.ToString(Request.Form["name"]);

            _categoryService.Update(category);

            return Redirect($"/User/GetById?id={category.Id}");
        }
    }
}
