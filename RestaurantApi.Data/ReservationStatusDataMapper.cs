
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
    public class ReservationStatusDataMapper
    {
        public ReservationStatusModel Create(ReservationStatusModel item)
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_INS_ReservationStatus";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            
            command.Parameters.AddWithValue("@StatusName", item.StatusName);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                item.Id = int.Parse(reader["Id"].ToString());
            }
            con.Close();
            return item;
        }

        public void Update(ReservationStatusModel item)
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_UPD_ReservationStatus";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            
            command.Parameters.AddWithValue("@Id", item.Id);
            command.Parameters.AddWithValue("@StatusName", item.StatusName);
            command.ExecuteNonQuery();
            con.Close();
        }

        public List<ReservationStatusModel>GetAll()
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_SEL_ReservationStatusGetAll";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            List<ReservationStatusModel> toReturn = new List<ReservationStatusModel>();
            while(reader.Read())
            {
                toReturn.Add(new ReservationStatusModel()
                {
                    
                Id = (int)reader["Id"],
                StatusName = (string)reader["StatusName"],   
                });
            }
            con.Close();
            return toReturn;
        }

        public ReservationStatusModel GetById(int Id)
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_SEL_ReservationStatusGetById";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", Id);
            SqlDataReader reader = command.ExecuteReader();
            ReservationStatusModel toReturn = null;
            while(reader.Read())
            {
                toReturn = new ReservationStatusModel()
                {
                    
                Id = (int)reader["Id"],
                StatusName = (string)reader["StatusName"],
                };
            }
            con.Close();
            return toReturn;
        }        
        
    }
}
            
