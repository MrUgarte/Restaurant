using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Datos;

namespace Restaurant.Negocios
{
    public class Manejadora
    {
        public List<Usuario> ListarUsuario()
        {
            List<Usuario> unaListaUsuario = new List<Usuario>();
            foreach (Datos.Usuario usuario in Conexion.Rest.Usuario)
            {
                Usuario nuevoUsuario = new Usuario(usuario.Nombre, usuario.Rut, usuario.contraseña, usuario.email, usuario.TipoUsuario);
                unaListaUsuario.Add(nuevoUsuario);
            }
            return unaListaUsuario;
        }

        public List<Producto> ListarProducto()
        {
            List<Producto> unalistaProducto = new List<Producto>();
            foreach (Datos.productos pro in Conexion.Rest.productos)
            {
                Producto nuevoProducto = new Producto(pro.Id_Producto, pro.Nombre_Producto, pro.Stock);
                unalistaProducto.Add(nuevoProducto);

            }
            return unalistaProducto;

        }
    }
    
}
