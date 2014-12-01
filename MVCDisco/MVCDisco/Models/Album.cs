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
    
    public partial class Album
    {
        public Album()
        {
            this.Cancion = new HashSet<Cancion>();
        }
    
        public int IdAlbum { get; set; }
        [Required]
        [StringLength(50,ErrorMessage="maximo 50 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [Range(1700,2016,ErrorMessage="El año debe estar comprendido entre 1700 y 2016")]
        public int Anio { get; set; }

        public System.DateTime FechaCreación { get; set; }
        public int IdUsuario { get; set; }

        public Nullable<int> IdArtista { get; set; }
    
        public virtual Artista Artista { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        public virtual ICollection<Cancion> Cancion { get; set; }
    }
}
