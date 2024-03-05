using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reci_Go.Repositories.Interfaces;
using Reci_Go.Models;
using System.Data.SqlClient;

namespace Reci_Go.Repositories.Implementations
{
    public class UsersRepository : IRepositoryGeneric<Users>
    {
        public Users Create(Users user)
        {
            int isAdmin = user.IsAdmin ? 1 : 0;
            int isBlocked = user.IsBlocked ? 1 : 0;

            string query = $"Insert into Users (name, email, password, username, is_blocked, is_admin)" +
                $" values" +
                $" ('{user.Name}', '{user.Email}', '{user.Password}', '{user.Username}', '{isBlocked}', '{isAdmin}');";
            
            MSSQL.ExecuteNonQuery(query);
            int id = MSSQL.GetMaxInt("id", "Users");
            return GetById(id);
        }

        public void Delete(int id)
        {
            string sql = $"Delete from Users where id={id}";
            MSSQL.ExecuteNonQuery(sql);
        }

        public IEnumerable<Users> GetAll()
        {
            string query = "SELECT * FROM Users;";
            SqlDataReader dataReader = MSSQL.Execute(query);
            List<Users> users = new List<Users>();
            while (dataReader.Read())
            {
                Users user = Parse(dataReader);
                users.Add(user);
            }
            return users;
        }

        public Users GetById(int id)
        {
            string query = $"Select * from Users where id={id};";
            SqlDataReader sqlDataReader = MSSQL.Execute(query);
            if (sqlDataReader.Read())
            {
                return Parse(sqlDataReader);
            }
            throw new Exception($"User Id {id} not found");
        }

        public Users Update(Users user)
        {
            int isAdmin = user.IsAdmin ? 1 : 0;
            int isBlocked = user.IsBlocked ? 1 : 0;

            string query = $"Update users" +
                $" set name = '{user.Name}', username = '{user.Username}', email = '{user.Email}', password = '{user.Password}', is_admin = '{isAdmin}', is_blocked = '{isBlocked}'" +
                $" where id = '{user.Id}'";
            MSSQL.ExecuteNonQuery(query);

            return GetById(user.Id);
        }

        private Users Parse(SqlDataReader dataReader)
        {
            Users user = new Users();
            user.Id = Convert.ToInt32(dataReader["id"]);
            user.Name = Convert.ToString(dataReader["name"]);
            user.Password = Convert.ToString(dataReader["password"]);
            user.Email = Convert.ToString(dataReader["email"]);
            user.Username = Convert.ToString(dataReader["username"]);
            user.IsAdmin = Convert.ToBoolean(dataReader["is_admin"]);
            user.IsBlocked = Convert.ToBoolean(dataReader["is_blocked"]);
            return user;
        }

    }
}
