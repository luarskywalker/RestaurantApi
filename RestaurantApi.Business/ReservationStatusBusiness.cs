
using RestaurantApi.Data;
using RestaurantApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApi.Business
{
    public static class ReservationStatusBusiness
    {
        public static ReservationStatusModel Create(ReservationStatusModel item)
        {           
           return new ReservationStatusDataMapper().Create(item);
        }

        public static void Update(ReservationStatusModel item)
        {
            ReservationStatusDataMapper ReservationStatusDM = new ReservationStatusDataMapper();
            ReservationStatusDM.Update(item);
        }

        public static List<ReservationStatusModel> GetAll()
        {
            return new ReservationStatusDataMapper().GetAll();
        }

        public static ReservationStatusModel GetById(int Id)
        {
            return new ReservationStatusDataMapper().GetById(Id);
        }

        
    }
}

