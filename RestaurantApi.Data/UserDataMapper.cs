
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApi.Model;
using System.Data;

namespace RestaurantApi.Data
{
    public class UserDataMapper
    {
        public UserModel LoginUser(string email, string password)
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_Login_User";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", password);
            SqlDataReader reader = command.ExecuteReader();
            UserModel toReturn = null;
            while (reader.Read())
            {
                toReturn = new UserModel()
                {

                    Id = (int)reader["Id"],
                    Email = (string)reader["Email"],
                    Password = (string)reader["Password"],
                    Name = (string)reader["Name"],
                    Address = (string)reader["Address"],
                };
            }
            con.Close();
            return toReturn;
        }

        public UserModel Create(UserModel item)
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_INS_User";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Email", item.Email);
            command.Parameters.AddWithValue("@Password", item.Password);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Address", item.Address);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                item.Id = int.Parse(reader["Id"].ToString());
            }
            con.Close();
            return item;
        }

        public void Update(UserModel item)
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_UPD_User";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", item.Id);
            command.Parameters.AddWithValue("@Email", item.Email);
            command.Parameters.AddWithValue("@Password", item.Password);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Address", item.Address);
            command.ExecuteNonQuery();
            con.Close();
        }

        public List<UserModel> GetAll()
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_SEL_UserGetAll";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            List<UserModel> toReturn = new List<UserModel>();
            while (reader.Read())
            {
                toReturn.Add(new UserModel()
                {

                    Id = (int)reader["Id"],
                    Email = (string)reader["Email"],
                    Password = (string)reader["Password"],
                    Name = (string)reader["Name"],
                    Address = (string)reader["Address"],
                });
            }
            con.Close();
            return toReturn;
        }

        public UserModel GetById(int Id)
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_SEL_UserGetById";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", Id);
            SqlDataReader reader = command.ExecuteReader();
            UserModel toReturn = null;
            while (reader.Read())
            {
                toReturn = new UserModel()
                {

                    Id = (int)reader["Id"],
                    Email = (string)reader["Email"],
                    Password = (string)reader["Password"],
                    Name = (string)reader["Name"],
                    Address = (string)reader["Address"],
                };
            }
            con.Close();
            return toReturn;
        }

        public UserModel GetByEmail(string email)
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_SEL_UserByEmail";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Email", email);
            SqlDataReader reader = command.ExecuteReader();
            UserModel toReturn = null;
            while (reader.Read())
            {
                toReturn = new UserModel()
                {

                    Id = (int)reader["Id"],
                    Email = (string)reader["Email"],
                    Password = (string)reader["Password"],
                    Name = (string)reader["Name"],
                    Address = (string)reader["Address"],
                };
            }
            con.Close();
            return toReturn;
        }

    }
}

