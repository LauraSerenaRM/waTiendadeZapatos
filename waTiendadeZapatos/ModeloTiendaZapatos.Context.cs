﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace waTiendadeZapatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dboTiendaZapatosEntities : DbContext
    {
        public dboTiendaZapatosEntities()
            : base("name=dboTiendaZapatosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblEmpleado> tblEmpleado { get; set; }
        public virtual DbSet<tblPedido> tblPedido { get; set; }
        public virtual DbSet<tblProducto> tblProducto { get; set; }
    }
}