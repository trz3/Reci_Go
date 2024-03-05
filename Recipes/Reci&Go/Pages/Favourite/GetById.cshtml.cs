using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reci_Go.Models;
using Reci_Go.Services.Interface;

namespace Reci_Go.Pages.Favourite
{
    public class GetByIdModel : PageModel
    {
		private readonly IServiceGeneric<Favourites> _favouritesService;

		public GetByIdModel(IServiceGeneric<Favourites> favouritesService)
		{
			_favouritesService = favouritesService;
		}

		public Favourites Favourite { get; set; }

		public void OnGet(int id)
		{

			Favourite = _favouritesService.GetById(id);
		}
	}
}
