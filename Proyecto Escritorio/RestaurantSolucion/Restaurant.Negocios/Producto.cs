using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Datos;

namespace Restaurant.Negocios
{
    public class Producto
    {
        private int _idProducto;
        public int IdProducto
        {
            get { return _idProducto; }
            set { _idProducto = value; }
        }

        private Produ _nombreProducto;
        public Produ NombreProducto
        {
            get { return _nombreProducto; }
            set { _nombreProducto = value; }
        }

        private int _stock;
        
        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        public Producto()
        {
            _idProducto = 0;
            _nombreProducto = Produ.arroz;
            _stock = 0;
        }

        public Producto(int pid,string pnom,int pstock)
        {
            _idProducto = pid;
            Produ pp;
            Enum.TryParse(pnom, out pp);
            _stock = pstock;
        }

        public bool Create()
        {
            try
            {
                Datos.productos pro = new Datos.productos()
                {
                    Id_Producto = this.IdProducto,
                    Nombre_Producto = NombreProducto.ToString(),
                    Stock=this.Stock
                };
                Conexion.Rest.productos.Add(pro);
                Conexion.Rest.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Read()
        {
            try
            {
                Datos.productos pro = (from auxpro in Conexion.Rest.productos
                                       where auxpro.Id_Producto == this.IdProducto
                                       select auxpro).First();

                this.IdProducto = pro.Id_Producto;
                Produ pp;
                Enum.TryParse(pro.Nombre_Producto, out pp);
                this.Stock = pro.Stock;
                
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update()
        {
            try
            {
                Datos.productos pro = Conexion.Rest.productos.First(p => p.Id_Producto == IdProducto);
                {
                    pro.Id_Producto = IdProducto;
                    pro.Nombre_Producto = NombreProducto.ToString();
                    pro.Stock = Stock;

                };
                Conexion.Rest.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete()
        {
            try
            {
                Datos.productos del = (from auxdel in Conexion.Rest.productos
                                       where auxdel.Id_Producto == this.IdProducto
                                       select auxdel).First();
                Conexion.Rest.productos.Remove(del);
                Conexion.Rest.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
