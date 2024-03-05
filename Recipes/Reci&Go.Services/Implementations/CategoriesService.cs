using Reci_Go.Models;
using Reci_Go.Repositories.Interfaces;
using Reci_Go.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reci_Go.Repositories.Interfaces;
using Reci_Go.Repositories.Implementations;

namespace Reci_Go.Services.Implementations
{
	public class CategoriesService : IServiceGeneric<Categories>
	{
		private readonly IRepositoryGeneric<Categories> _categoriesRepository = new CategoriesRepository();

		public CategoriesService(IRepositoryGeneric<Categories> categoriesRepository)
		{
			_categoriesRepository = categoriesRepository;
		}

		public Categories Create(Categories category)
		{
			return _categoriesRepository.Create(category);
		}

		public bool Delete(int id)
		{
			_categoriesRepository.Delete(id);
			return true;
		}

		public IEnumerable<Categories> GetAll()
		{
			return _categoriesRepository.GetAll();
		}

		public Categories GetById(int id)
		{
			return _categoriesRepository.GetById(id);
		}

		public Categories Update(Categories category)
		{
			throw new NotImplementedException();
		}
	}
}
