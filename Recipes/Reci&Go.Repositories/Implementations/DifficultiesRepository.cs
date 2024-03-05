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
	public class DifficultiesRepository : IRepositoryGeneric<Difficulties>
	{
		public Difficulties Create(Difficulties difficulty)
		{
			string query = $"Insert into Difficulties (name)" +
				$"values" +
				$"('{difficulty.Name}');";
			MSSQL.ExecuteNonQuery(query);
			int id = MSSQL.GetMaxInt("id", "Difficulties");
			return GetById(id);
		}

		public void Delete(int id)
		{
			string query = $"Delete from Difficulties where id = '{id}'";
			MSSQL.ExecuteNonQuery(query);
		}

		public IEnumerable<Difficulties> GetAll()
		{
			string query = "Select * from Difficulties;";
			SqlDataReader dataReader = MSSQL.Execute(query);
			List<Difficulties> difficulty = new List<Difficulties>();
			while (dataReader.Read())
			{
				difficulty.Add(Parse(dataReader));
			}
			return difficulty;
		}

		public Difficulties GetById(int id)
		{
			string query = $"Select * from Difficulties where id = {id}";
			SqlDataReader dataReader = MSSQL.Execute(query);
			if (dataReader.Read())
			{
				return Parse(dataReader);
			}
			throw new Exception($"Difficulty id {id} not found");
		}

		public Difficulties Update(Difficulties difficulty)
		{
			throw new NotImplementedException();
		}

		private Difficulties Parse(SqlDataReader dataReader)
		{
			Difficulties difficulty = new Difficulties();
			difficulty.Id = Convert.ToInt32(dataReader["id"]);
			difficulty.Name = Convert.ToString(dataReader["name"]);
			return difficulty;
		}
	}
}
