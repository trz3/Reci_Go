using Reci_Go.Models;
using Reci_Go.Services.Interface;
using Reci_Go.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Channels;
using System.Data;

namespace Reci_Go.ConsoleApp
{
    public class Program
    {
        private static readonly IServiceGeneric<Users> _userService = new UsersService();

        public static void Main(string[] args)
        {

            Menu();
        }

        public static void Menu()
        {
            Console.WriteLine("1 - Add");
            Console.WriteLine("2 - Check all ");
            Console.WriteLine("3 - Check one ");
            Console.WriteLine("4 - Update one ");
            int opc = int.Parse(Console.ReadLine());

            switch (opc)
            {
                case 1:
                    Create();
                    break;
                case 2:
                    GetAll();
                    break;
                case 3:
                    GetById();
                    break;
                case 4:
                    Update();
                    break;
            }
            
        }

        private static void Update()
        {
            throw new NotImplementedException();
        }

        private static void GetById()
        {
            throw new NotImplementedException();
        }

        private static void GetAll()
        {
            throw new NotImplementedException();
        }

        private static void Create()
        {
            _userService.Create();
        }
    }
}