using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace RestaurantApi.Data
{
    public class Conexion
    {
        string cadenaConexion;

        public string CadenaConexion
        {
            get { return cadenaConexion; }
            set { cadenaConexion = value; }
        }

        public Conexion()
        {
            LeerCadenaConexion();
        }

        public bool LeerCadenaConexion()
        {
            bool respuesta = true;
            CadenaConexion = "";
            try
            {
                CadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["DBAccess"].ConnectionString;
                if (CadenaConexion == "")
                {
                    respuesta = false;

                }
            }
            catch (Exception exception)
            {
                respuesta = false;
                throw new Exception(exception.Message);
            }
            return respuesta;
        }

    }
}
