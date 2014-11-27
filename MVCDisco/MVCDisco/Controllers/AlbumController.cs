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


            return View(albumServicio.OrdenarAlbumPorNombre());
        }

        [HttpPost]
        public ActionResult Index(string IdArtista)
        {

            ViewBag.IdArtista = new SelectList(artistaServicio.BuscarArtistas(), "IdArtista", "NombreCompleto");
            int resultado;
            if (int.TryParse(IdArtista, out resultado))
            {

                return View(albumServicio.FiltrarAlbumsPorArtista(Int32.Parse(IdArtista)));

            }

            return View(albumServicio.OrdenarAlbumPorNombre());
        }





        //
        // GET: /Album/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Album/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Album/Create

        [HttpPost]
        public ActionResult Create(Album album)
        {
            albumServicio.CrearAlbum(album);
            return RedirectToAction("Index");
        }

        //
        // GET: /Album/Edit/5

        public ActionResult Edit(int id)
        {
            
            return View ("");
        }

        //
        // POST: /Album/Edit/5

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
           
            return View("");
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
