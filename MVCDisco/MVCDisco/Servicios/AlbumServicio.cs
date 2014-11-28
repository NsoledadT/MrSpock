using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDisco.Models;
using System.Data;

namespace MVCDisco.Servicios
{
    public class AlbumServicio
    {
        TP20142CEntities1 db = new TP20142CEntities1();

        //Metodo obtiene una lista de albums ordenada por nombre
        public List<Album> OrdenarAlbumPorNombre()
        {
            return (from n in db.Album orderby n.Nombre select n).ToList();
        }

        //Metodo que obtiene una lista de canciones segun album
        public List<Album> FiltrarAlbumsPorArtista(int id)
        {
            return (from n in db.Album where n.Artista.IdArtista == id select n).ToList();
        }


        //Metodo que obtiene todos los albumes
        public List<Album> BuscarTodoAlbum()
        {
            return db.Album.ToList();
        }

        //Metodo que crea Album
        public bool CrearAlbum(Album album)
        {
            album.FechaCreación = DateTime.Now;
            db.Album.Add(album);
            db.SaveChanges();
            return true;
        }

        //Metodo que borra Album
        public bool BorrarAlbum(int id)
        {
            var can = from a in db.Cancion where a.IdAlbum == id select a;

            foreach (var ca in can)
            {
                db.Cancion.Remove(ca);
            }

            db.Album.Remove((from c in db.Album where c.IdAlbum == id select c).FirstOrDefault());

            db.SaveChanges();
            return true;
        }

        public bool EditarAlbum(int id)
        {
            Album album = (from e in db.Album where e.IdAlbum == id select e).FirstOrDefault();
            if (album == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool EditarAlbum(Album album) {
            db.Entry(album).State = EntityState.Modified;
            db.SaveChanges();
            return true;
              }

    }

}