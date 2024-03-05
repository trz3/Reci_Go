using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reci_Go.Models;
using Reci_Go.Services.Implementations;
using Reci_Go.Services.Interface;

namespace Reci_Go.Pages.Category
{
    public class GetAllModel : PageModel
    {
        private readonly IServiceGeneric<Categories> _categoriesService;

        public GetAllModel (IServiceGeneric<Categories> categoriesService)
        {
            _categoriesService = categoriesService;
        }

        public List<Categories> Categories { get; set; }

        public void OnGet()
        {
            
            Categories = (List<Categories>)_categoriesService.GetAll();
        }
    }
}
