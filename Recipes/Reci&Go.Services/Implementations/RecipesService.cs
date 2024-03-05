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
	public class RecipesService : IServiceGeneric<Recipes>
	{
		private readonly IRepositoryGeneric<Recipes> _recipeRepository = new RecipesRepository();

		public RecipesService(IRepositoryGeneric<Recipes> recipeRepository) 
		{
			_recipeRepository = recipeRepository;
		}
		public Recipes Create(Recipes recipe)
		{
			return _recipeRepository.Create(recipe);
		}

		public bool Delete(int id)
		{
			_recipeRepository.Delete(id);
			return true;
		}

		public IEnumerable<Recipes> GetAll()
		{
			return _recipeRepository.GetAll();
		}

		public Recipes GetById(int id)
		{
			return _recipeRepository.GetById(id);
		}

		public Recipes Update(Recipes recipe)
		{
			throw new NotImplementedException();
		}
	}
}
