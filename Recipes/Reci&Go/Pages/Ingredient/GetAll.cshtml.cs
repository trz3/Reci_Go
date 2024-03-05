using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reci_Go.Models;
using Reci_Go.Services.Implementations;
using Reci_Go.Services.Interface;

namespace Reci_Go.Pages.Ingredient
{
    public class GetAllModel : PageModel
    {
        private readonly IServiceGeneric<Ingredients> _ingredientService;

        public GetAllModel (IServiceGeneric<Ingredients> ingredientService)
        {
			_ingredientService = ingredientService;
        }

        public List<Ingredients> Ingredients { get; set; }

        public void OnGet()
        {

			Ingredients = (List<Ingredients>)_ingredientService.GetAll();
        }
    }
}
