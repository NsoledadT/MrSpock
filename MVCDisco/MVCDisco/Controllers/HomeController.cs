﻿using System;
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

                if (usuarioServicio.usuarioValido(user.Email, user.Contrasenia))
                {
                    if (usuarioServicio.usuarioInactivo(user.Email, user.Contrasenia))
                    {
                        ViewBag.Text = "Usuario Inactivo";
                        return View();
                    }
                    else
                    {

                        return View("Login");
                    }
                }
                else
                {
                    ViewBag.Text = "usuario invalido";
                    return View();
                }

            }

            return View();
        }



        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
