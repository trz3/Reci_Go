using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_Go.Repositories.Interfaces
{
    public interface IRepositoryGeneric<T>
    {
        T Create(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Update(T entity);
        void Delete(int id);
    }
}
