﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class fiscaliaEntities : DbContext
    {
        public fiscaliaEntities()
            : base("name=fiscaliaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<colaDistribucion> colaDistribucions { get; set; }
        public virtual DbSet<colaDistribucionLog> colaDistribucionLogs { get; set; }
        public virtual DbSet<tiposDistribucione> tiposDistribuciones { get; set; }
        public virtual DbSet<usuario> usuarios { get; set; }
    }
}
