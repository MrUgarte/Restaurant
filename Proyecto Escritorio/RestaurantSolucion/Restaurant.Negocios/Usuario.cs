using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Datos;

namespace Restaurant.Negocios
{
    public class Usuario
    {
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (value.Length > 0)
                {
                    _nombre = value;
                }
                else
                {
                    throw new ArgumentException("error...debe ingresar usuario");
                }
            }
        }

        private string _rut;

        public string Rut
        {
            get { return _rut; }
            set
            {
                if (value.Length > 0)
                {
                    _rut = value;
                }
                else
                {
                    throw new ArgumentException("error...debe ingresar rut");
                }
            }
        }

        private string _contraseña;

        public string Contraseña
        {
            get { return _contraseña; }
            set
            {
                if (value.Length > 0)
                {
                    _contraseña = value;
                }
                else
                {
                    throw new ArgumentException("error...debe ingresar contraseña");
                }
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                if (value.Length > 0)
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("error...debe ingresar email");
                }
            }
        }

        private Tipo _tipo;

        public Tipo Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public Usuario()
        {
            _nombre = string.Empty;
            _rut = string.Empty;
            _contraseña = string.Empty;
            _email = string.Empty;
            _tipo = Tipo.Administrador;
        }

        public Usuario(string u,string r,string c ,string e,string tipoS)
        {
            _nombre = u;
            _rut = r;
            _contraseña = c;
            _email = e;
            Tipo tt;
            Enum.TryParse(tipoS, out tt);
            _tipo = tt;
        }

        public bool Create()
        {
            try
            {
                Datos.Usuario us = new Datos.Usuario()
                {
                    Nombre = this.Nombre,
                    Rut = this.Rut,
                    contraseña = this.Contraseña,
                    email = this.Email,
                    TipoUsuario = Tipo.ToString()
                };
                Conexion.Rest.Usuario.Add(us);
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
                Datos.Usuario us = (from auxpaa in Conexion.Rest.Usuario
                                    where auxpaa.Rut == this.Rut
                                  select auxpaa).First();
                this.Nombre = us.Nombre;
                this.Rut = us.Rut;
                this.Contraseña = us.contraseña;
                this.Email = us.email;
                Tipo t;
                Enum.TryParse(us.TipoUsuario, out t);
                this.Tipo = t;
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Readd()
        {
            try
            {
                Datos.Usuario us = (from auxpaa in Conexion.Rest.Usuario
                                    where (auxpaa.Rut == this.Rut && auxpaa.contraseña == this.Contraseña)
                                    select auxpaa).First();
                this.Nombre = us.Nombre;
                this.Rut = us.Rut;
                this.Contraseña = us.contraseña;
                this.Email = us.email;
                Tipo t;
                Enum.TryParse(us.TipoUsuario, out t);
                this.Tipo = t;
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
                Datos.Usuario uss = Conexion.Rest.Usuario.First(p => p.Rut == Rut);
                {
                    uss.Nombre = Nombre;
                    uss.Rut = Rut;
                    uss.contraseña = Contraseña;
                    uss.email = Email;
                    uss.TipoUsuario = Tipo.ToString();

                };
                Conexion.Rest.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delate()
        {
            try
            {
                Datos.Usuario ss = (from auxaa in Conexion.Rest.Usuario
                                    where auxaa.Rut == this.Rut
                                    select auxaa).First();
                Conexion.Rest.Usuario.Remove(ss);
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
