using Reci_Go.Models;
using Reci_Go.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_Go.Repositories.Implementations
{
	public class RecipeIngredientsRepository : IRepositoryGeneric<RecipeIngredients>
	{
		public RecipeIngredients Create(RecipeIngredients recipeIngredients)
		{
			string query = $"Insert into RecipeIngredients (quantity, id_recipe, id_ingredient, id_measure)" +
				$"values" +
				$"('{recipeIngredients.Quantity}', '{recipeIngredients.Recipes.Id}', '{recipeIngredients.Ingredients.Id}', '{recipeIngredients.Measures.Id}');";
			MSSQL.ExecuteNonQuery(query);
			int id = MSSQL.GetMaxInt("id", "RecipeIngredients");
			return GetById(id);
		}

		public void Delete(int id)
		{
			string query = $"Delete from RecipeIngredients where id = '{id}'";
			MSSQL.ExecuteNonQuery(query);
		}

		public IEnumerable<RecipeIngredients> GetAll()
		{
			string query = "Select * from RecipeIngredients;";
			SqlDataReader dataReader = MSSQL.Execute(query);
			List<RecipeIngredients> recipeIngredients = new List<RecipeIngredients>();
			while (dataReader.Read())
			{
				recipeIngredients.Add(Parse(dataReader));
			}
			return recipeIngredients;
		}

		public RecipeIngredients GetById(int id)
		{
			string query = $"Select * from RecipeIngredients where id = {id}";
			SqlDataReader dataReader = MSSQL.Execute(query);
			if (dataReader.Read())
			{
				return Parse(dataReader);
			}
			throw new Exception($"Difficulty id {id} not found");
		}

		public RecipeIngredients Update(RecipeIngredients recipeIngredients)
		{
			throw new NotImplementedException();
		}

		private RecipeIngredients Parse(SqlDataReader dataReader)
		{
			RecipeIngredients recipeIngredients = new RecipeIngredients();
			recipeIngredients.Id = Convert.ToInt32(dataReader["id"]);
			recipeIngredients.Quantity = Convert.ToInt32(dataReader["quantity"]);
			recipeIngredients.Ingredients = new Ingredients();
			recipeIngredients.Ingredients.Id = Convert.ToInt32(dataReader["id_ingredients"]);
			recipeIngredients.Recipes = new Recipes();
			recipeIngredients.Recipes.Id = Convert.ToInt32(dataReader["id_recipe"]);
			recipeIngredients.Measures = new Measures();
			recipeIngredients.Measures.Id = Convert.ToInt32(dataReader["id_measure"]);

			return recipeIngredients;
		}

	}
}
