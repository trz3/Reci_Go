using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reci_Go.Models;
using Reci_Go.Services.Interface;

namespace Reci_Go.Pages.Rating
{
    public class GetAllModel : PageModel
    {
        private readonly IServiceGeneric<Ratings> _ratingService;

        public GetAllModel(IServiceGeneric<Ratings> ratingService)
        {
            _ratingService = ratingService;
        }

        public List<Ratings> Ratings { get; set; }

        public void OnGet()
        {

            Ratings = (List<Ratings>)_ratingService.GetAll();
        }
    }
}
