using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reci_Go.Models;
using Reci_Go.Services.Interface;

namespace Reci_Go.Pages.Difficulty
{
    public class GetByIdModel : PageModel
    {
		private readonly IServiceGeneric<Difficulties> _difficultiesService;

		public GetByIdModel(IServiceGeneric<Difficulties> difficultiesService)
		{
            _difficultiesService = difficultiesService;
		}

		public Difficulties Difficulty { get; set; }

		public void OnGet(int id)
		{

            Difficulty = _difficultiesService.GetById(id);
		}
	}
}
