
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
    public class ReservationDataMapper
    {
        public ReservationModel Create(ReservationModel item)
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_INS_Reservation";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            
            command.Parameters.AddWithValue("@IdUser", item.IdUser);
            command.Parameters.AddWithValue("@IdRestaurant", item.IdRestaurant);
            command.Parameters.AddWithValue("@IdReservationStatus", item.IdReservationStatus);
            command.Parameters.AddWithValue("@ReservationHour", item.ReservationHour);
            command.Parameters.AddWithValue("@ReservationNotes", item.ReservationNotes);
            command.Parameters.AddWithValue("@ContactNumber", item.ContactNumber);
            command.Parameters.AddWithValue("@ReservationName", item.ReservationName);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                item.Id = int.Parse(reader["Id"].ToString());
            }
            con.Close();
            return item;
        }

        public void Update(ReservationModel item)
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_UPD_Reservation";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            
            command.Parameters.AddWithValue("@Id", item.Id);
            command.Parameters.AddWithValue("@IdUser", item.IdUser);
            command.Parameters.AddWithValue("@IdRestaurant", item.IdRestaurant);
            command.Parameters.AddWithValue("@IdReservationStatus", item.IdReservationStatus);
            command.Parameters.AddWithValue("@ReservationHour", item.ReservationHour);
            command.Parameters.AddWithValue("@ReservationNotes", item.ReservationNotes);
            command.Parameters.AddWithValue("@ContactNumber", item.ContactNumber);
            command.Parameters.AddWithValue("@ReservationName", item.ReservationName);
            command.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int Id)
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_DEL_ReservationById";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", Id);
            command.ExecuteNonQuery();
            con.Close();
        }

        public List<ReservationModel>GetAll()
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_SEL_ReservationGetAll";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            List<ReservationModel> toReturn = new List<ReservationModel>();
            while(reader.Read())
            {
                toReturn.Add(new ReservationModel()
                {
                    
                Id = (int)reader["Id"],
                IdUser = (int)reader["IdUser"],
                IdRestaurant = (int)reader["IdRestaurant"],
                IdReservationStatus = (int)reader["IdReservationStatus"],
                ReservationHour = (DateTime)reader["ReservationHour"],
                ReservationNotes = (string)reader["ReservationNotes"],
                ContactNumber = (string)reader["ContactNumber"],
                ReservationName = (string)reader["ReservationName"],   
                });
            }
            con.Close();
            return toReturn;
        }

        public ReservationModel GetById(int Id)
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_SEL_ReservationGetById";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", Id);
            SqlDataReader reader = command.ExecuteReader();
            ReservationModel toReturn = null;
            while(reader.Read())
            {
                toReturn = new ReservationModel()
                {
                    
                Id = (int)reader["Id"],
                IdUser = (int)reader["IdUser"],
                IdRestaurant = (int)reader["IdRestaurant"],
                IdReservationStatus = (int)reader["IdReservationStatus"],
                ReservationHour = (DateTime)reader["ReservationHour"],
                ReservationNotes = (string)reader["ReservationNotes"],
                ContactNumber = (string)reader["ContactNumber"],
                ReservationName = (string)reader["ReservationName"],
                };
            }
            con.Close();
            return toReturn;
        }                

        public List<ReservationModel> GetByUser(int IdUser)
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_SEL_ReservationGetAllByUser";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdUser", IdUser);
            SqlDataReader reader = command.ExecuteReader();
            List<ReservationModel> toReturn = new List<ReservationModel>();
            while(reader.Read())
            {
                toReturn.Add(new ReservationModel()
                {
                    
                Id = (int)reader["Id"],
                IdUser = (int)reader["IdUser"],
                IdRestaurant = (int)reader["IdRestaurant"],
                IdReservationStatus = (int)reader["IdReservationStatus"],
                ReservationHour = (DateTime)reader["ReservationHour"],
                ReservationNotes = (string)reader["ReservationNotes"],
                ContactNumber = (string)reader["ContactNumber"],
                ReservationName = (string)reader["ReservationName"],   
                });
            }
            con.Close();
            return toReturn;
        }

        public List<ReservationModel> GetByRestaurant(int IdRestaurant)
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_SEL_ReservationGetAllByRestaurant";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdRestaurant", IdRestaurant);
            SqlDataReader reader = command.ExecuteReader();
            List<ReservationModel> toReturn = new List<ReservationModel>();
            while(reader.Read())
            {
                toReturn.Add(new ReservationModel()
                {
                    
                Id = (int)reader["Id"],
                IdUser = (int)reader["IdUser"],
                IdRestaurant = (int)reader["IdRestaurant"],
                IdReservationStatus = (int)reader["IdReservationStatus"],
                ReservationHour = (DateTime)reader["ReservationHour"],
                ReservationNotes = (string)reader["ReservationNotes"],
                ContactNumber = (string)reader["ContactNumber"],
                ReservationName = (string)reader["ReservationName"],   
                });
            }
            con.Close();
            return toReturn;
        }

        public List<ReservationModel> GetByReservationStatus(int IdReservationStatus)
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_SEL_ReservationGetAllByReservationStatus";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdReservationStatus", IdReservationStatus);
            SqlDataReader reader = command.ExecuteReader();
            List<ReservationModel> toReturn = new List<ReservationModel>();
            while(reader.Read())
            {
                toReturn.Add(new ReservationModel()
                {
                    
                Id = (int)reader["Id"],
                IdUser = (int)reader["IdUser"],
                IdRestaurant = (int)reader["IdRestaurant"],
                IdReservationStatus = (int)reader["IdReservationStatus"],
                ReservationHour = (DateTime)reader["ReservationHour"],
                ReservationNotes = (string)reader["ReservationNotes"],
                ContactNumber = (string)reader["ContactNumber"],
                ReservationName = (string)reader["ReservationName"],   
                });
            }
            con.Close();
            return toReturn;
        }

        public ReservationModel GetByHour(DateTime hour)
        {
            SqlConnection con = new SqlConnection(new Conexion().CadenaConexion);
            con.Open();
            String sqlCommand = "dbo.PA_SEL_ReservationByHour";
            SqlCommand command = new SqlCommand(sqlCommand, con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Hour", hour);
            SqlDataReader reader = command.ExecuteReader();
            ReservationModel toReturn = null;
            while (reader.Read())
            {
                toReturn = new ReservationModel()
                {

                    Id = (int)reader["Id"],
                    IdUser = (int)reader["IdUser"],
                    IdRestaurant = (int)reader["IdRestaurant"],
                    IdReservationStatus = (int)reader["IdReservationStatus"],
                    ReservationHour = (DateTime)reader["ReservationHour"],
                    ReservationNotes = (string)reader["ReservationNotes"],
                    ContactNumber = (string)reader["ContactNumber"],
                    ReservationName = (string)reader["ReservationName"],
                };
            }
            con.Close();
            return toReturn;

        }
    }
}
            
