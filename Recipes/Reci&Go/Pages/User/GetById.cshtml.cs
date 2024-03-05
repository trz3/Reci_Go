using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reci_Go.Models;
using Reci_Go.Services;
using Reci_Go.Services.Implementations;
using Reci_Go.Services.Interface;

namespace Reci_Go.Pages.User
{
    public class GetByIdModel : PageModel
    {
        private readonly IServiceGeneric<Users> _usersService;
        public GetByIdModel(IServiceGeneric<Users> usersService)
        {
            _usersService = usersService;
        }


        public Users User { get; set; }

        public void OnGet(int id)
        {
            User = _usersService.GetById(id);
            
        }


    }
}
