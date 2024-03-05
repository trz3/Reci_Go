using Reci_Go.Models;
using Reci_Go.Repositories.Implementations;
using Reci_Go.Repositories.Interfaces;
using Reci_Go.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_Go.Services.Implementations
{
	public class IngredientService : IServiceGeneric<Ingredients>
	{
		private readonly IRepositoryGeneric<Ingredients> _ingredientsRepository = new IngredientsRepository();

		public IngredientService(IRepositoryGeneric<Ingredients> ingredientsRepository)
		{
			_ingredientsRepository = ingredientsRepository;
		}

		public Ingredients Create(Ingredients ingredients)
		{
			return _ingredientsRepository.Create(ingredients);
		}

		public bool Delete(int id)
		{
			_ingredientsRepository.Delete(id);
			return true;
		}

		public IEnumerable<Ingredients> GetAll()
		{
			return _ingredientsRepository.GetAll();
		}

		public Ingredients GetById(int id)
		{
			return _ingredientsRepository.GetById(id);
		}

		public Ingredients Update(Ingredients ingredients)
		{
			throw new NotImplementedException();
		}
	}
}
