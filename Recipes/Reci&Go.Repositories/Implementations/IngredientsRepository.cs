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
	public class IngredientsRepository : IRepositoryGeneric<Ingredients>
	{
		public Ingredients Create(Ingredients ingredient)
		{
			string query = $"Insert into Ingredients (name)" +
				$"values" +
				$"('{ingredient.Name}');";
			MSSQL.ExecuteNonQuery(query);
			int id = MSSQL.GetMaxInt("id", "Ingredients");
			return GetById(id);
		}

		public void Delete(int id)
		{
			string query = $"Delete from Ingredients where id = '{id}'";
			MSSQL.ExecuteNonQuery(query);
		}

		public IEnumerable<Ingredients> GetAll()
		{
			string query = "Select * from Ingredients;";
			SqlDataReader dataReader = MSSQL.Execute(query);
			List<Ingredients> ingredients = new List<Ingredients>();
			while (dataReader.Read())
			{
				ingredients.Add(Parse(dataReader));
			}
			return ingredients;
		}

		public Ingredients GetById(int id)
		{
			string query = $"Select * from Ingredients where id = {id}";
			SqlDataReader dataReader = MSSQL.Execute(query);
			if (dataReader.Read())
			{
				return Parse(dataReader);
			}
			throw new Exception($"Category id {id} not found");
		}

		public Ingredients Update(Ingredients ingredient)
		{
			throw new NotImplementedException();
		}

		private Ingredients Parse(SqlDataReader dataReader)
		{
			Ingredients category = new Ingredients();
			category.Id = Convert.ToInt32(dataReader["id"]);
			category.Name = Convert.ToString(dataReader["name"]);
			return category;
		}
	}
}
