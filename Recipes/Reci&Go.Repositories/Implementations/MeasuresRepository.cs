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
	public class MeasuresRepository : IRepositoryGeneric<Measures>
	{
		public Measures Create(Measures measure)
		{
			string query = $"Insert into Categories (name)" +
				$"values" +
				$"('{measure.Name}');";
			MSSQL.ExecuteNonQuery(query);
			int id = MSSQL.GetMaxInt("id", "Measures");
			return GetById(id);
		}

		public void Delete(int id)
		{
			string query = $"Delete from Measures where id = '{id}'";
			MSSQL.ExecuteNonQuery(query);
		}

		public IEnumerable<Measures> GetAll()
		{
			string query = "Select * from Measures;";
			SqlDataReader dataReader = MSSQL.Execute(query);
			List<Measures> measures = new List<Measures>();
			while (dataReader.Read())
			{
				measures.Add(Parse(dataReader));
			}
			return measures;
		}

		public Measures GetById(int id)
		{
			string query = $"Select * from Measures where id = {id}";
			SqlDataReader dataReader = MSSQL.Execute(query);
			if (dataReader.Read())
			{
				return Parse(dataReader);
			}
			throw new Exception($"Measures id {id} not found");
		}

		public Measures Update(Measures measure)
		{
			throw new NotImplementedException();
		}

		private Measures Parse(SqlDataReader dataReader)
		{
			Measures measure = new Measures();
			measure.Id = Convert.ToInt32(dataReader["id"]);
			measure.Name = Convert.ToString(dataReader["name"]);
			return measure;
		}
	}
}
