using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApi.Model
{
    public class RestaurantsResponse : Response
    {
        public List<RestaurantModel> Restaurants { get; set; }
    }
}
