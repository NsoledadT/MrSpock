//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCDisco.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Artista
    {
        public Artista()
        {
            this.Album = new HashSet<Album>();
        }
    
        public int IdArtista { get; set; }

       [Required(ErrorMessage = "Ingrese un nombre")]
        public string NombreCompleto { get; set; }
    
        public virtual ICollection<Album> Album { get; set; }
    }
}
