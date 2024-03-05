using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reci_Go.Models;
using Reci_Go.Services.Interface;

namespace Reci_Go.Pages.Measure
{
    public class GetAllModel : PageModel
    {
		private readonly IServiceGeneric<Measures> _measuresService;

		public GetAllModel(IServiceGeneric<Measures> measuresService)
		{
			_measuresService = measuresService;
		}

		public List<Measures> Measures { get; set; }

		public void OnGet()
		{

			Measures = (List<Measures>)_measuresService.GetAll();
		}
	}
}
