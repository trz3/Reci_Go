using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reci_Go.Models;
using Reci_Go.Services.Implementations;
using Reci_Go.Services.Interface;

namespace Reci_Go.Pages.Ingredient
{
    public class UpdateModel : PageModel
    {
        private readonly IServiceGeneric<Ingredients> _ingredientsService;

        public UpdateModel(IServiceGeneric<Ingredients> ingredientsService)
        {
            _ingredientsService = ingredientsService;
        }
        public Ingredients Ingredient { get; set; }

        public void OnGet(int id)
        {
            Ingredient = _ingredientsService.GetById(id);
        }

        public IActionResult OnPost()
        {
            Ingredients ingredient = new Ingredients();
            ingredient.Id = Convert.ToInt32(Request.Form["id"]);
            ingredient.Name = Convert.ToString(Request.Form["name"]);

            _ingredientsService.Update(ingredient);

            return Redirect($"/User/GetById?id={ingredient.Id}");
        }
    }
}
