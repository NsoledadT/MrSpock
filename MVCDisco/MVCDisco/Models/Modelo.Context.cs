﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TP20142CEntities1 : DbContext
    {
        public TP20142CEntities1()
            : base("name=TP20142CEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Album> Album { get; set; }
        public DbSet<Artista> Artista { get; set; }
        public DbSet<Cancion> Cancion { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
