
using RestaurantApi.Data;
using RestaurantApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApi.Business
{
    public static class RestaurantBusiness
    {
        public static RestaurantModel Create(RestaurantModel item)
        {           
           return new RestaurantDataMapper().Create(item);
        }

        public static void Update(RestaurantModel item)
        {
            RestaurantDataMapper RestaurantDM = new RestaurantDataMapper();
            RestaurantDM.Update(item);
        }

        public static List<RestaurantModel> GetAll()
        {
            return new RestaurantDataMapper().GetAll();
        }

        public static RestaurantModel GetById(int Id)
        {
            return new RestaurantDataMapper().GetById(Id);
        }

        
    }
}

