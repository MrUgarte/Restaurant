using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Datos;

namespace Restaurant.Negocios
{
    internal class Conexion
    {
        private static RestaurantBDEntities _rest;
        public static RestaurantBDEntities Rest
        {
            get
            {
                if (_rest == null)
                {
                    _rest = new RestaurantBDEntities();
                }
                return _rest;
            }
            set
            {
                _rest = value;
            }
        }
    }
}
