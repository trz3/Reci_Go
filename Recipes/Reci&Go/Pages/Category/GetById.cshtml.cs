using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reci_Go.Models;
using Reci_Go.Services.Interface;

namespace Reci_Go.Pages.Category
{
    public class GetByIdModel : PageModel
    {
		private readonly IServiceGeneric<Categories> _categoriesService;

		public GetByIdModel(IServiceGeneric<Categories> categoriesService)
		{
            _categoriesService = categoriesService;
		}

		public Categories Category { get; set; }

		public void OnGet(int id)
		{

            Category = _categoriesService.GetById(id);
		}
	}
}
