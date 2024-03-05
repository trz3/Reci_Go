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
	public class RecipeIngredientService : IServiceGeneric<RecipeIngredients>
	{

		private readonly IRepositoryGeneric<RecipeIngredients> _recipeIngredientsRepository = new RecipeIngredientsRepository();

		public RecipeIngredientService(IRepositoryGeneric<RecipeIngredients> recipeIngredientsRepository)
		{
			_recipeIngredientsRepository = recipeIngredientsRepository;
		}

		public RecipeIngredients Create(RecipeIngredients recipeIngredient)
		{
			return _recipeIngredientsRepository.Create(recipeIngredient);
		}

		public bool Delete(int id)
		{
			_recipeIngredientsRepository.Delete(id);
			return true;
		}

		public IEnumerable<RecipeIngredients> GetAll()
		{
			return _recipeIngredientsRepository.GetAll();
		}

		public RecipeIngredients GetById(int id)
		{
			return _recipeIngredientsRepository.GetById(id);
		}

		public RecipeIngredients Update(RecipeIngredients recipeIngredient)
		{
			throw new NotImplementedException();
		}
	}
}
