using RestaurantApi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestaurantApi
{
    [ServiceContract]
    public interface IRestaurantApiService
    {
        [OperationContract]
        [Description("Allows to login into the api")]
        LoginResponse Login(string email, string password);

        [OperationContract]
        [Description("Creates an user into the api")]
        Response CreateUser(UserModel request);

        [OperationContract]
        [Description("Retrieves all restaurants into the database")]
        RestaurantsResponse GetRestaurants();

        [OperationContract]
        [Description("Creates a reservation for a restaurant")]
        ReservationResponse CreateReservation(ReservationModel request, string token);

        [OperationContract]
        [Description("Obtains all reservations created by the user who make the request")]
        ReservationsResponse GetReservations(string token);

        [OperationContract]
        [Description("Updates the selected reservation")]
        Response UpdateReservation(ReservationModel request, string token);

        [OperationContract]
        [Description("Delete the selected reservation")]
        Response DeleteReservation(int idReservation, string token);

        [OperationContract]
        [Description("Obtains the selected reservation")]
        ReservationResponse GetReservation(int idReservation, string token);
    }
}
