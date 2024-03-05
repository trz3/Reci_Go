using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reci_Go.Models;
using Reci_Go.Services.Interface;

namespace Reci_Go.Pages.User
{
    public class GetAllModel : PageModel
    {
		private readonly IServiceGeneric<Users> _usersService;
		public GetAllModel(IServiceGeneric<Users> usersService)
		{
			_usersService = usersService;
		}
		public List<Users> Users { get; set; }
        public void OnGet()
        {
			Users = (List<Users>)_usersService.GetAll();
        }
    }
}
