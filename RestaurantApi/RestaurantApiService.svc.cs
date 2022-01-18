using RestaurantApi.Business;
using RestaurantApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestaurantApi
{
    public class RestaurantApiService : IRestaurantApiService
    {
        public ReservationResponse CreateReservation(ReservationModel request, string token)
        {
            try
            {
                var validation = UserBusiness.ValidateUser(token);
                if (validation.Status)
                {
                    if (validation.IdUser.Value == request.IdUser)
                    {
                        return ReservationBusiness.Create(request);
                    }
                    else
                    {
                        return new ReservationResponse()
                        {
                            Success = false,
                            Message = "Reservation does not belong to the current user."
                        };
                    }
                }
                else
                {
                    return new ReservationResponse()
                    {
                        Message = "User token expired or incorrect. Please login again.",
                        Success = false
                    };
                }
            }
            catch (Exception)
            {
                return new ReservationResponse()
                {
                    Message = "It was not possible to process the request. Please retry. If this message continues, please contact with your service provider.",
                    Success = false
                };
            }
        }

        public Response CreateUser(UserModel request)
        {
            try
            {
                var newUserResponse = UserBusiness.Create(request);
                return newUserResponse;
            }
            catch (Exception)
            {
                return new NewUserResponse()
                {
                    Message = "It was not possible to process the request. Please retry. If this message continues, please contact with your service provider",
                    Success = false
                };
            }
        }

        public ReservationResponse GetReservation(int idReservation, string token)
        {
            try
            {
                var validation = UserBusiness.ValidateUser(token);
                if (validation.Status)
                {
                    var reservation = ReservationBusiness.GetById(idReservation);
                    if (validation.IdUser.Value == reservation.IdUser)
                    {
                        return new ReservationResponse()
                        {
                            Reservation = reservation,
                            Success = true
                        };
                    }
                    else
                    {
                        return new ReservationResponse()
                        {
                            Success = false,
                            Message = "Reservation does not belong to the current user."
                        };
                    }
                }
                else
                {
                    return new ReservationResponse()
                    {
                        Message = "User token expired or incorrect. Please login again",
                        Success = false
                    };
                }
            }
            catch (Exception)
            {
                return new ReservationResponse()
                {
                    Message = "It was not possible to process the request. Please retry. If this message continues, please contact with your service provider",
                    Success = false
                };
            }
        }

        public Response UpdateReservation(ReservationModel request, string token)
        {
            try
            {
                var validation = UserBusiness.ValidateUser(token);
                if (validation.Status)
                {
                    if (validation.IdUser.Value == request.IdUser)
                    {
                        ReservationBusiness.Update(request);
                        return new Response()
                        {
                            Success = true
                        };
                    }
                    else
                    {
                        return new Response()
                        {
                            Success = false,
                            Message = "Reservation does not belong to the current user."
                        };
                    }
                }
                else
                {
                    return new Response()
                    {
                        Message = "User token expired or incorrect. Please login again",
                        Success = false
                    };
                }
            }
            catch (Exception)
            {
                return new Response()
                {
                    Message = "It was not possible to process the request. Please retry. If this message continues, please contact with your service provider",
                    Success = false
                };
            }
        }

        public Response DeleteReservation(int idReservation, string token)
        {
            try
            {
                var reservation = ReservationBusiness.GetById(idReservation);
                var validation = UserBusiness.ValidateUser(token);
                if (validation.Status)
                {
                    if (validation.IdUser.Value == reservation.IdUser)
                    {
                        ReservationBusiness.Delete(idReservation);
                        return new Response()
                        {
                            Success = true
                        };
                    }
                    else
                    {
                        return new Response()
                        {
                            Success = false,
                            Message = "Reservation does not belong to the current user."
                        };
                    }
                }
                else
                {
                    return new Response()
                    {
                        Message = "User token expired or incorrect. Please login again",
                        Success = false
                    };
                }
            }
            catch (Exception)
            {
                return new Response()
                {
                    Message = "It was not possible to process the request. Please retry. If this message continues, please contact with your service provider",
                    Success = false
                };
            }
        }

        public ReservationsResponse GetReservations(string token)
        {
            try
            {
                var validation = UserBusiness.ValidateUser(token);
                if (validation.Status)
                {
                    return new ReservationsResponse()
                    {
                        Reservations = ReservationBusiness.GetByUser(validation.IdUser.Value),
                        Success = true
                    };
                }
                else
                {
                    return new ReservationsResponse()
                    {
                        Message = "User token expired or incorrect. Please login again",
                        Success = false
                    };
                }
            }
            catch (Exception)
            {
                return new ReservationsResponse()
                {
                    Message = "It was not possible to process the request. Please retry. If this message continues, please contact with your service provider",
                    Success = false
                };
            }
        }

        public RestaurantsResponse GetRestaurants()
        {
            try
            {
                var restaurants = RestaurantBusiness.GetAll();
                return new RestaurantsResponse()
                {
                    Success = true,
                    Restaurants = restaurants
                };
            }
            catch (Exception)
            {
                return new RestaurantsResponse()
                {
                    Message = "It was not possible to process the request. Please retry. If this message continues, please contact with your service provider",
                    Success = false
                };
            }
        }

        public LoginResponse Login(string email, string password)
        {
            try
            {
                return UserBusiness.Login(email, password);
            }
            catch (Exception)
            {
                return new LoginResponse()
                {
                    Message = "It was not possible to process the request. Please retry. If this message continues, please contact with your service provider",
                    Success = false
                };
            }
        }
    }
}
