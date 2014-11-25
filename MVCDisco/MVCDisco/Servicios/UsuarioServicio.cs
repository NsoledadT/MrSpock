using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDisco.Models;

namespace MVCDisco.Servicios
{
    public class UsuarioServicio
    {
        TP20142CEntities1 db = new TP20142CEntities1();

        public bool usuarioValido(string email, string contra)
        {
            var valido = (from u in db.Usuarios where u.Email == email && u.Contrasenia == contra select u).FirstOrDefault();

            if (valido != null)
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        public bool usuarioInactivo(string email, string contra)
        {

            var inactivo = (from c in db.Usuarios
                            where c.Email == email && c.Contrasenia == contra && c.Estado == 0
                            select c).FirstOrDefault();

            if (inactivo != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}