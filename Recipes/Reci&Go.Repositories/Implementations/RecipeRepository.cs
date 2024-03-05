using Reci_Go.Models;
using Reci_Go.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Reci_Go.Repositories.Implementations
{
	public class RecipesRepository : IRepositoryGeneric<Recipes>
	{
		public Recipes Create(Recipes recipe)
		{
			string query = $"Insert into Recipe (title, preperation_method, id_category, id_difficulty, preparation_time, is_approved, id_user)" +
				$"values" +
				$"('{recipe.Title}','{recipe.PreparationMethod}','{recipe.Categories.Id}','{recipe.Difficulties.Id}','{recipe.PreparationTime}','{recipe.Users.Id}')";
			MSSQL.ExecuteNonQuery(query);
			int id = MSSQL.GetMaxInt("id", "Recipes");
			return GetById(id);
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Recipes> GetAll()
		{
			string query = "Select * from Recipe";
			SqlDataReader dataReader = MSSQL.Execute(query);
			List<Recipes> recipe = new List<Recipes>();
			while(dataReader.Read())
			{
				recipe.Add(Parse(dataReader));
			}
			return recipe;
		}

		public Recipes GetById(int id)
		{
			string query = $"Select * from Recipes where id = {id}";
			SqlDataReader dataReader = MSSQL.Execute(query);
			if (dataReader.Read())
			{
				return Parse(dataReader);
			}
			throw new Exception($"Recipe id {id} not found");
		}

		public Recipes Update(Recipes recipe)
		{
			throw new NotImplementedException();
		}
		public Recipes Parse(SqlDataReader dataReader)
		{
			Recipes recipe = new Recipes();
			recipe.Title = Convert.ToString(dataReader["title"]);
			recipe.PreparationMethod = Convert.ToString(dataReader["preparation_method"]);
			recipe.PreparationTime = Convert.ToDateTime(dataReader["preparation_time"]);
			recipe.IsApproved = Convert.ToBoolean(dataReader["is_approved"]);

			recipe.Users = new Users();
			recipe.Users.Id = Convert.ToInt32(dataReader["id_user"]);

			recipe.Categories = new Categories();
			recipe.Categories.Id = Convert.ToInt32(dataReader["id_category"]);

			recipe.Difficulties = new Difficulties();
			recipe.Difficulties.Id = Convert.ToInt32(dataReader["id_difficulty"]);

			return recipe;
		}
	}
}
