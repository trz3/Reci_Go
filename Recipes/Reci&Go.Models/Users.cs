using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_Go.Models
{
    public class Users
    {

        public int Id { get; set; } 
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }  
        public string Username { get; set; }    
        public bool IsAdmin { get; set; }   
        public bool IsBlocked {  get; set; }

        public Users() { }

        public Users(int id, string name, string password, string email, string username, bool isAdmin, bool isBlocked)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            Username = username;
            IsAdmin = isAdmin;
            IsBlocked = isBlocked;
        }
    }
}
