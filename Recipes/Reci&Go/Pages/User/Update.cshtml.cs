using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reci_Go.Services.Implementations;
using Reci_Go.Services.Interface;
using Reci_Go.Models;

namespace Reci_Go.Pages.User
{
    public class UpdateModel : PageModel
    {

        private readonly IServiceGeneric<Users> _userService = new UsersService();

        public UpdateModel (IServiceGeneric<Users> userService)
        {
            _userService = userService;
        }
        public Users User { get; set; }

        public void OnGet(int id)
        {
            User = _userService.GetById(id);
        }

        public IActionResult OnPost() 
        {
            Users user = new Users();
            user.Id = Convert.ToInt32(Request.Form["id"]);
            user.Username = Convert.ToString(Request.Form["username"]);
            user.Name = Convert.ToString(Request.Form["name"]);
            user.Email = Convert.ToString(Request.Form["email"]);
            user.Password = Convert.ToString(Request.Form["password"]);
            user.IsAdmin = Convert.ToBoolean(Request.Form["is_admin"]);
            user.IsBlocked = Convert.ToBoolean(Request.Form["is_blocked"]);

            _userService.Update(user);

            return Redirect($"/User/GetById?id={user.Id}");
        }
    }
}
