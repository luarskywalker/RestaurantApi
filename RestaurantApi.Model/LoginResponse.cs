using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApi.Model
{
    public class LoginResponse : Response
    {
        public int? IdUser { get; set; }
        public string SessionKey { get; set; }
    }
}
