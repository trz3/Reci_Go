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
	public class RatingsRepository : IRepositoryGeneric<Ratings>
	{
		public Ratings Create(Ratings rating)
		{
			string query = $"Insert into Ratings (name)" +
				$"values" +
				$"('{rating.Name}');";
			MSSQL.ExecuteNonQuery(query);
			int id = MSSQL.GetMaxInt("id", "Ratings");
			return GetById(id);
		}

		public void Delete(int id)
		{
			string query = $"Delete from Ratings where id = '{id}'";
			MSSQL.ExecuteNonQuery(query);

		}

		public IEnumerable<Ratings> GetAll()
		{
			string query = "Select * from Ratings;";
			SqlDataReader dataReader = MSSQL.Execute(query);
			List<Ratings> rating = new List<Ratings>();
			while (dataReader.Read())
			{
				rating.Add(Parse(dataReader));
			}
			return rating;
		}

		public Ratings GetById(int id)
		{
			string query = $"Select * from Ratings where id = {id}";
			SqlDataReader dataReader = MSSQL.Execute(query);
			if (dataReader.Read())
			{
				return Parse(dataReader);
			}
			throw new Exception($"Category id {id} not found");
		}

		public Ratings Update(Ratings rating)
		{
			throw new NotImplementedException();
		}

		private Ratings Parse(SqlDataReader dataReader)
		{
			Ratings rating = new Ratings();
			rating.Id = Convert.ToInt32(dataReader["id"]);
			rating.Name = Convert.ToString(dataReader["name"]);
			return rating;
		}
	}
}
