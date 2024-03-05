using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reci_Go.Models;
using Reci_Go.Services.Implementations;
using Reci_Go.Services.Interface;

namespace Reci_Go.Pages.Difficulty
{
    public class GetAllModel : PageModel
    {
        private readonly IServiceGeneric<Difficulties> _difficultiesService;

        public GetAllModel (IServiceGeneric<Difficulties> difficultiesService)
        {
            _difficultiesService = difficultiesService;
        }

        public List<Difficulties> Difficulties { get; set; }

        public void OnGet()
        {
            
            Difficulties = (List<Difficulties>)_difficultiesService.GetAll();
        }
    }
}
