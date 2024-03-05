using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reci_Go.Models;
using Reci_Go.Services.Interface;

namespace Reci_Go.Pages.Rating
{
    public class GetByIdModel : PageModel
    {
		private readonly IServiceGeneric<Ratings> _ratingsService;

		public GetByIdModel(IServiceGeneric<Ratings> ratingsService)
		{
			_ratingsService = ratingsService;
		}

		public Ratings Rating { get; set; }

		public void OnGet(int id)
		{

			Rating = _ratingsService.GetById(id);
		}
	}
}
