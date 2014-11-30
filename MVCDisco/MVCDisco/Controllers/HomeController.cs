using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDisco.Models;
using MVCDisco.Servicios;

namespace MVCDisco.Controllers
{
    public class HomeController : Controller
    {
        UsuarioServicio usuarioServicio = new UsuarioServicio();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            Usuarios user = new Usuarios();

            if (ModelState.IsValid)
            {

                user.Email = form["email"];
                user.Contrasenia = form["contrasenia"];
                int IdUsuario = user.IdUsuario;

                if (usuarioServicio.usuarioValido(user.Email, user.Contrasenia))
                {
                    if (usuarioServicio.usuarioInactivo(user.Email, user.Contrasenia))
                    {
                        ViewBag.Text = "Usuario Inactivo";
                        return View();
                    }
                    else
                    {
                        this.Session["nombre"] = usuarioServicio.ObtenerUsuario(user.Email, user.Contrasenia).Nombre;
                        this.Session["id"] = usuarioServicio.ObtenerUsuario(user.Email, user.Contrasenia).IdUsuario;
                        ViewBag.Text = "Bienvenido" + "," + this.Session["nombre"];
                        return View("Login");
                    }
                }
                else
                {
                    ViewBag.Text = "Verifique usuario y/o contraseña";
                    return View();
                }

            }

            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

    }
}
