using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reci_Go.Services.Implementations;
using Reci_Go.Services.Interface;
using Reci_Go.Models;
using Reci_Go.Repositories.Interfaces;
using Reci_Go.Repositories.Implementations;

namespace Reci_Go.Services.Implementations
{
    public class UsersService : IServiceGeneric<Users>
    {
        private readonly IRepositoryGeneric<Users> _usersRepository = new UsersRepository();

        public UsersService(IRepositoryGeneric<Users> usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public UsersService() { }

        public Users Create(Users user)
        {
            return _usersRepository.Create(user);
        }

        public bool Delete(int id)
        {
            _usersRepository.Delete(id);
            return true;
        }

        public IEnumerable<Users> GetAll()
        {
           return _usersRepository.GetAll();
        }

        public Users GetById(int id)
        {
            return _usersRepository.GetById(id);
        }

        public Users Update(Users user)
        {
            return _usersRepository.Update(user);
        }
    }
}
