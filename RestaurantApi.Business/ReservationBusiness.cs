
using RestaurantApi.Data;
using RestaurantApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApi.Business
{
    public static class ReservationBusiness
    {
        public static ReservationResponse Create(ReservationModel item)
        {
            ReservationDataMapper rdm = new ReservationDataMapper();
            var reserv = rdm.GetByHour(item.ReservationHour);
            if (reserv != null)
            {
                return new ReservationResponse()
                {
                    Success = false,
                    Message = "There is already a reservation at the selected hour",
                };
            }
            else
            {
                var newReserv = new ReservationDataMapper().Create(item);
                return new ReservationResponse()
                {
                    Success = true,
                    Reservation = newReserv
                };
            }
        }

        public static void Update(ReservationModel item)
        {
            ReservationDataMapper ReservationDM = new ReservationDataMapper();
            ReservationDM.Update(item);
        }

        public static void Delete(int IdReservation)
        {
            ReservationDataMapper ReservationDM = new ReservationDataMapper();
            ReservationDM.Delete(IdReservation);
        }

        public static ReservationModel GetById(int Id)
        {
            return new ReservationDataMapper().GetById(Id);
        }

        public static List<ReservationModel> GetByUser(int IdUser)
        {
            return new ReservationDataMapper().GetByUser(IdUser);
        }

    }
}

