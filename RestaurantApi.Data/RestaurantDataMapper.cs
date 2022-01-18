
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
    public class RestaurantDataMapper
    {
        public RestaurantModel Create(RestaurantModel item)
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_INS_Restaurant";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Address", item.Address);
            command.Parameters.AddWithValue("@OpeningHour", item.OpeningHour);
            command.Parameters.AddWithValue("@ClosingHour", item.ClosingHour);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                item.Id = int.Parse(reader["Id"].ToString());
            }
            con.Close();
            return item;
        }

        public void Update(RestaurantModel item)
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_UPD_Restaurant";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            
            command.Parameters.AddWithValue("@Id", item.Id);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Address", item.Address);
            command.Parameters.AddWithValue("@OpeningHour", item.OpeningHour);
            command.Parameters.AddWithValue("@ClosingHour", item.ClosingHour);
            command.ExecuteNonQuery();
            con.Close();
        }

        public List<RestaurantModel>GetAll()
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_SEL_RestaurantGetAll";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            List<RestaurantModel> toReturn = new List<RestaurantModel>();
            while(reader.Read())
            {
                toReturn.Add(new RestaurantModel()
                {
                    
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Address = (string)reader["Address"],
                OpeningHour = (DateTime)reader["OpeningHour"],
                ClosingHour = (DateTime)reader["ClosingHour"],   
                });
            }
            con.Close();
            return toReturn;
        }

        public RestaurantModel GetById(int Id)
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_SEL_RestaurantGetById";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", Id);
            SqlDataReader reader = command.ExecuteReader();
            RestaurantModel toReturn = null;
            while(reader.Read())
            {
                toReturn = new RestaurantModel()
                {
                    
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Address = (string)reader["Address"],
                OpeningHour = (DateTime)reader["OpeningHour"],
                ClosingHour = (DateTime)reader["ClosingHour"],
                };
            }
            con.Close();
            return toReturn;
        }        
        
    }
}
            
