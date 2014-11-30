using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDisco.Models;
using MVCDisco.Servicios;

namespace MVCDisco.Controllers
{
    public class CancionController : Controller
    {

        AlbumServicio albumServicio = new AlbumServicio();
        CancionServicio cancionServicio= new CancionServicio();
        //
        // GET: /Cancion/

        public ActionResult Index()
        {
          
            ViewBag.IdAlbum = new SelectList(albumServicio.BuscarTodoAlbum((int)this.Session["id"]), "IdAlbum", "Nombre");
           
             
            return View(cancionServicio.OrdenarCancionPorNombre((int)this.Session["id"]));
        }


                [HttpPost]
        public ActionResult Index(string IdAlbum)
        {

            ViewBag.IdAlbum = new SelectList(albumServicio.BuscarTodoAlbum((int)this.Session["id"]), "IdAlbum", "Nombre");
            int resultado;
               if(int.TryParse(IdAlbum, out resultado)){

                   return View(cancionServicio.FiltrarCancionPorAlbum(Int32.Parse(IdAlbum)));

               }

               return View(cancionServicio.OrdenarCancionPorNombre((int)this.Session["id"]));
        }

   

        //
        // GET: /Cancion/Create

        public ActionResult Create()
        {
            ViewBag.IdAlbum = new SelectList(albumServicio.BuscarTodoAlbum((int)this.Session["id"]), "IdAlbum", "Nombre");
            return View();
        }

        //
        // POST: /Cancion/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cancion cancion)
        {

            cancion.IdUsuario = (int)this.Session["id"];

            if (ModelState.IsValid)
            {

                String letra = cancion.IdAlbum.ToString();
                int resultado;
                if (int.TryParse(letra, out resultado))
                {
                    if (cancionServicio.EvaluarCrearCancion(resultado,cancion.Nombre))
                    {
                        DentroIf();
                        return View();

                    }
                    FueraIf(cancion);
                    return RedirectToAction("Index");
                   

                }

                else
                {
                    if (cancionServicio.EvaluarCrearCancion(cancion.Nombre))
                    {
                        DentroIf();
                        return View();
                    }

                    FueraIf(cancion);
                    return RedirectToAction("Index");
                }
               
              }

            ViewBag.IdAlbum = new SelectList(albumServicio.BuscarTodoAlbum((int)this.Session["id"]), "IdAlbum", "Nombre", cancion.IdAlbum);
            return View(cancion);
            
        }

        //
        // GET: /Cancion/Edit/5

        public ActionResult Edit(int id)
        {

            return View(cancionServicio.ObtenerCancion(id));
        }

        //
        // POST: /Cancion/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {
           if (ModelState.IsValid)
            {
              
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
           else
            {
                return View();
            }
        }

        //
        // GET: /Cancion/Delete/5

        public ActionResult Delete(int id)
        {
            cancionServicio.BorrarCancion(id);
            return RedirectToAction("Index");
        }

      

        private void DentroIf()
        {
            ViewBag.Mensaje = "El nombre ya exite Cambie el nombre o el album";
            ViewBag.IdAlbum = new SelectList(albumServicio.BuscarTodoAlbum((int)this.Session["id"]), "IdAlbum", "Nombre");
        }

        private void FueraIf(Cancion cancion)
        {
            cancionServicio.CrearCancion(cancion);
            ViewBag.IdAlbum = new SelectList(albumServicio.BuscarTodoAlbum((int)this.Session["id"]), "IdAlbum", "Nombre");
        }
    }
}
