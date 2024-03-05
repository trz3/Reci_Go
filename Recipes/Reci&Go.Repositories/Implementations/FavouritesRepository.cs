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
	public class FavouritesRepository : IRepositoryGeneric<Favourites>
	{

		public Favourites Create(Favourites favourite)
		{
			string query = $"Insert into Favourites (id_user, id_recipe)" +
				$"values" +
				$"('{favourite.Users.Id}', '{favourite.Recipes.Id}');";
			MSSQL.ExecuteNonQuery(query);
			int id = MSSQL.GetMaxInt("id", "Favourites");
			return GetById(id);
		}

		public void Delete(int id)
		{
			string query = $"Delete from Favourites where id = '{id}'";
			MSSQL.ExecuteNonQuery(query);
		}

		public IEnumerable<Favourites> GetAll()
		{
			string query = "Select * from Favourites;";
			SqlDataReader dataReader = MSSQL.Execute(query);
			List<Favourites> favourite = new List<Favourites>();
			while (dataReader.Read())
			{
				favourite.Add(Parse(dataReader));
			}
			return favourite;
		}

		public Favourites GetById(int id)
		{
			string query = $"Select * from Favourites where id = {id}";
			SqlDataReader dataReader = MSSQL.Execute(query);
			if (dataReader.Read())
			{
				return Parse(dataReader);
			}
			throw new Exception($"Difficulty id {id} not found");
		}

		public Favourites Update(Favourites favourite)
		{
			throw new NotImplementedException();
		}

		private Favourites Parse(SqlDataReader dataReader)
		{
			Favourites favourite = new Favourites();
			favourite.Id = Convert.ToInt32(dataReader["id"]);
			favourite.Users = new Users();
			favourite.Users.Id = Convert.ToInt32(dataReader["id_user"]);
			favourite.Recipes = new Recipes();
			favourite.Recipes.Id = Convert.ToInt32(dataReader["id_recipe"]);
			return favourite;
		}

	}
}
