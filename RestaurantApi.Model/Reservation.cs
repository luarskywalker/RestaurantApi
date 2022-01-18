
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApi.Model
{
    public class ReservationModel
    {
        
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdRestaurant { get; set; }
        public int IdReservationStatus { get; set; }
        public DateTime ReservationHour { get; set; }
        public string ReservationNotes { get; set; }
        public string ContactNumber { get; set; }
        public string ReservationName { get; set; }

    }
}
