using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_Go.Services.Interface
{
    public interface IServiceGeneric<T>
    {
        T Create(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Update(T entity);
        bool Delete(int id);

    }
}
