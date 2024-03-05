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
	public class ReviewsRepository : IRepositoryGeneric<Reviews>
	{
		public Reviews Create(Reviews review)
		{
			string query = $"Insert into Reviews (comment, id_user, id_rating, id_recipe)" +
				$"values" +
				$"('{review.Comment}', '{review.Users.Id}', '{review.Ratings.Id}', '{review.Recipes.Id}');";
			MSSQL.ExecuteNonQuery(query);
			int id = MSSQL.GetMaxInt("id", "Reviews");
			return GetById(id);
		}

		public void Delete(int id)
		{
			string query = $"Delete from Reviews where id = '{id}'";
			MSSQL.ExecuteNonQuery(query);
		}

		public IEnumerable<Reviews> GetAll()
		{
			string query = "Select * from Reviews;";
			SqlDataReader dataReader = MSSQL.Execute(query);
			List<Reviews> review = new List<Reviews>();
			while (dataReader.Read())
			{
				review.Add(Parse(dataReader));
			}
			return review;
		}

		public Reviews GetById(int id)
		{
			string query = $"Select * from Reviews where id = {id}";
			SqlDataReader dataReader = MSSQL.Execute(query);
			if (dataReader.Read())
			{
				return Parse(dataReader);
			}
			throw new Exception($"Difficulty id {id} not found");
		}

		public Reviews Update(Reviews review)
		{
			throw new NotImplementedException();
		}

		private Reviews Parse(SqlDataReader dataReader)
		{
			Reviews review = new Reviews();
			review.Id = Convert.ToInt32(dataReader["id"]);
			review.Comment = dataReader["comment"].ToString();
			review.Users = new Users();
			review.Users.Id = Convert.ToInt32(dataReader["id_user"]);
			review.Ratings = new Ratings();
			review.Ratings.Id = Convert.ToInt32(dataReader["id_rating"]);
			review.Recipes = new Recipes();
			review.Recipes.Id = Convert.ToInt32(dataReader["id_recipe"]);

			return review;
		}
	}
}
