using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reci_Go.Models;
using Reci_Go.Services.Interface;

namespace Reci_Go.Pages.Measure
{
    public class GetByIdModel : PageModel
    {
        private readonly IServiceGeneric<Measures> _measuresService;

        public GetByIdModel(IServiceGeneric<Measures> measuresService)
        {
            _measuresService = measuresService;
        }

        public Measures Measure { get; set; }

        public void OnGet(int id)
        {

            Measure = _measuresService.GetById(id);
        }
    }
}
