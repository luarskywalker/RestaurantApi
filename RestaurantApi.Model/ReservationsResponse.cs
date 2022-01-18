using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApi.Model
{
    public class ReservationsResponse:Response
    {
        public List<ReservationModel> Reservations { get; set; }
    }
}
