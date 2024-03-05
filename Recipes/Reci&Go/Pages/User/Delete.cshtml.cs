using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reci_Go.Services.Implementations;
using Reci_Go.Services.Interface;
using Reci_Go.Models;

namespace Reci_Go.Pages.User
{
    public class DeleteModel : PageModel
    {
        private readonly IServiceGeneric<Users> _userService = new UsersService();

        public DeleteModel(IServiceGeneric<Users> userService) 
        {
            _userService = userService; 
        }
        public IActionResult OnGet(int id)
        {
            _userService.Delete(id);
            return Redirect("/GetAll");
        }
    }
}
