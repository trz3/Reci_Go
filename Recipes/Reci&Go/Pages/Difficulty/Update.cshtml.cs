using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reci_Go.Models;
using Reci_Go.Services.Implementations;
using Reci_Go.Services.Interface;

namespace Reci_Go.Pages.Difficulty
{
    public class UpdateModel : PageModel
    {
        private readonly IServiceGeneric<Difficulties> _difficultyService;

        public UpdateModel(IServiceGeneric<Difficulties> difficultyService)
        {
            _difficultyService = difficultyService;
        }
        public Difficulties Difficulty { get; set; }

        public void OnGet(int id)
        {
            Difficulty = _difficultyService.GetById(id);
        }

        public IActionResult OnPost()
        {
            Difficulties category = new Difficulties();
            category.Id = Convert.ToInt32(Request.Form["id"]);
            category.Name = Convert.ToString(Request.Form["name"]);

            _difficultyService.Update(category);

            return Redirect($"/User/GetById?id={category.Id}");
        }
    }
}
