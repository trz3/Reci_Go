using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reci_Go.Models;
using Reci_Go.Services.Interface;

namespace Reci_Go.Pages.Ingredient
{
    public class GetByIdModel : PageModel
    {
		private readonly IServiceGeneric<Ingredients> _ingredientsService;

		public GetByIdModel(IServiceGeneric<Ingredients> ingredientsService)
		{
            _ingredientsService = ingredientsService;
		}

		public Ingredients Ingredient { get; set; }

		public void OnGet(int id)
		{

            Ingredient = _ingredientsService.GetById(id);
		}
	}
}
