using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reci_Go.Models;
using Reci_Go.Services.Implementations;
using Reci_Go.Services.Interface;

namespace Reci_Go.Pages.Favourite
{
    public class GetAllModel : PageModel
    {
        private readonly IServiceGeneric<Favourites> _favouriteService;

        public GetAllModel (IServiceGeneric<Favourites> favouriteService)
        {
			_favouriteService = favouriteService;
        }

        public List<Favourites> Favourites { get; set; }

        public void OnGet()
        {

			Favourites = (List<Favourites>)_favouriteService.GetAll();
        }
    }
}
