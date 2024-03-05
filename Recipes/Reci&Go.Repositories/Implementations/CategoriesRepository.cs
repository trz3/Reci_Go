using Reci_Go.Models;
using Reci_Go.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Reci_Go.Repositories.Implementations
{
	public class CategoriesRepository : IRepositoryGeneric<Categories>
	{
		public Categories Create(Categories category)
		{
			string query = $"Insert into Categories (name)" +
				$"values" +
				$"('{category.Name}');";
			MSSQL.ExecuteNonQuery(query);
			int id = MSSQL.GetMaxInt("id", "Categories");
			return GetById(id);
		}

		public void Delete(int id)
		{
			string query = $"Delete from Categories where id = '{id}'";
			MSSQL.ExecuteNonQuery(query);

		}

		public IEnumerable<Categories> GetAll()
		{
			string query = "Select * from Categories;";
			SqlDataReader dataReader = MSSQL.Execute(query);
			List<Categories> categories = new List<Categories>();
			while (dataReader.Read())
			{
				categories.Add(Parse(dataReader));
			}
			return categories;
		}

		public Categories GetById(int id)
		{
			string query = $"Select * from Categories where id = {id}";
			SqlDataReader dataReader = MSSQL.Execute(query);
			if (dataReader.Read())
			{
				return Parse(dataReader);
			}
			throw new Exception($"Category id {id} not found");
		}

		public Categories Update(Categories categories)
		{
			throw new NotImplementedException();
		}

		private Categories Parse (SqlDataReader dataReader)
		{
			Categories category = new Categories();
			category.Id = Convert.ToInt32(dataReader["id"]);
			category.Name = Convert.ToString(dataReader["name"]);
			return category;
		}
	}
}
