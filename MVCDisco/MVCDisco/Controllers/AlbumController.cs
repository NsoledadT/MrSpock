using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDisco.Models;
using MVCDisco.Servicios;

namespace MVCDisco.Controllers
{
    public class AlbumController : Controller
    {
        AlbumServicio albumServicio = new AlbumServicio();
        ArtistaServicio artistaServicio = new ArtistaServicio();

        //
        // GET: /Album/

        public ActionResult Index()
        {

            ViewBag.IdArtista = new SelectList(artistaServicio.BuscarArtistas(), "IdArtista", "NombreCompleto");


            return View(albumServicio.OrdenarAlbumPorNombre((int)this.Session["id"]));
        }

        [HttpPost]
        public ActionResult Index(string IdArtista)
        {

            ViewBag.IdArtista = new SelectList(artistaServicio.BuscarArtistas(), "IdArtista", "NombreCompleto");
            int resultado;
            if (int.TryParse(IdArtista, out resultado))
            {

                return View(albumServicio.FiltrarAlbumsPorArtista(Int32.Parse(IdArtista), (int)this.Session["id"]));

            }

            return View(albumServicio.OrdenarAlbumPorNombre((int)this.Session["id"]));
        }





        // GET: /Album/Create

        public ActionResult Create()
        {
            ViewBag.IdArtista = new SelectList(artistaServicio.BuscarArtistas(), "IdArtista", "NombreCompleto");
            return View();
        }

        //
        // POST: /Album/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Album album)
        {
            album.IdUsuario = (int)this.Session["id"];
            if (ModelState.IsValid)
            {
              
                    albumServicio.CrearAlbum(album);
                    return RedirectToAction("Index");
               
            }
            else
            {
                ViewBag.IdArtista = new SelectList(artistaServicio.BuscarArtistas(), "IdArtista", "NombreCompleto");
                return View();
            }
        }

        //
        // GET: /Album/Edit/5

        public ActionResult Edit(int id)
        {

            ViewBag.IdArtista = new SelectList(artistaServicio.BuscarArtistas(), "IdArtista", "NombreCompleto");
            return View( albumServicio.ObtenerAlbum(id));
           
        }

        //
        // POST: /Album/Edit/5

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                album.IdUsuario = (int)this.Session["id"];
                albumServicio.EditarAlbum(album);
                
                return RedirectToAction("Index");
            }

            ViewBag.IdArtista = new SelectList(artistaServicio.BuscarArtistas(), "IdArtista", "NombreCompleto");
            return View(album);
        }

        //
        // GET: /Album/Delete/5

        public ActionResult Delete(int id)
        {
            albumServicio.BorrarAlbum(id);
            return RedirectToAction("Index");
        }

        //
        // POST: /Album/Delete/5

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
