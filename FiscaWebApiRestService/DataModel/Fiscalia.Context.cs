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
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
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
        public virtual DbSet<Juicios_Registro> Juicios_Registro { get; set; }
        public virtual DbSet<EFPersona> EFPersonas { get; set; }
    
        public virtual ObjectResult<GetJuiciosByUsuario_Result> GetJuiciosByUsuario(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetJuiciosByUsuario_Result>("GetJuiciosByUsuario", idUsuarioParameter);
        }
    
        public virtual int EFDeletePersona(Nullable<int> idPersona)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("idPersona", idPersona) :
                new ObjectParameter("idPersona", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EFDeletePersona", idPersonaParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> EFinsertPersona(Nullable<int> idTipoPersona, string apellido, string nombre, Nullable<int> idTipoDocumento, string cuit, Nullable<decimal> numeroDocumento, Nullable<int> idEstadoCivil, string nacionalidad, Nullable<int> idTipoSociedad, string tipoPersoneria, string registro, string numeroSociedad, string fechaInscripcion, string tomo, string letra, string folio, Nullable<bool> sexo, Nullable<System.DateTime> fechaAlta, Nullable<int> idUsuarioAlta)
        {
            var idTipoPersonaParameter = idTipoPersona.HasValue ?
                new ObjectParameter("idTipoPersona", idTipoPersona) :
                new ObjectParameter("idTipoPersona", typeof(int));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("apellido", apellido) :
                new ObjectParameter("apellido", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var idTipoDocumentoParameter = idTipoDocumento.HasValue ?
                new ObjectParameter("idTipoDocumento", idTipoDocumento) :
                new ObjectParameter("idTipoDocumento", typeof(int));
    
            var cuitParameter = cuit != null ?
                new ObjectParameter("cuit", cuit) :
                new ObjectParameter("cuit", typeof(string));
    
            var numeroDocumentoParameter = numeroDocumento.HasValue ?
                new ObjectParameter("numeroDocumento", numeroDocumento) :
                new ObjectParameter("numeroDocumento", typeof(decimal));
    
            var idEstadoCivilParameter = idEstadoCivil.HasValue ?
                new ObjectParameter("idEstadoCivil", idEstadoCivil) :
                new ObjectParameter("idEstadoCivil", typeof(int));
    
            var nacionalidadParameter = nacionalidad != null ?
                new ObjectParameter("nacionalidad", nacionalidad) :
                new ObjectParameter("nacionalidad", typeof(string));
    
            var idTipoSociedadParameter = idTipoSociedad.HasValue ?
                new ObjectParameter("idTipoSociedad", idTipoSociedad) :
                new ObjectParameter("idTipoSociedad", typeof(int));
    
            var tipoPersoneriaParameter = tipoPersoneria != null ?
                new ObjectParameter("tipoPersoneria", tipoPersoneria) :
                new ObjectParameter("tipoPersoneria", typeof(string));
    
            var registroParameter = registro != null ?
                new ObjectParameter("registro", registro) :
                new ObjectParameter("registro", typeof(string));
    
            var numeroSociedadParameter = numeroSociedad != null ?
                new ObjectParameter("numeroSociedad", numeroSociedad) :
                new ObjectParameter("numeroSociedad", typeof(string));
    
            var fechaInscripcionParameter = fechaInscripcion != null ?
                new ObjectParameter("fechaInscripcion", fechaInscripcion) :
                new ObjectParameter("fechaInscripcion", typeof(string));
    
            var tomoParameter = tomo != null ?
                new ObjectParameter("tomo", tomo) :
                new ObjectParameter("tomo", typeof(string));
    
            var letraParameter = letra != null ?
                new ObjectParameter("letra", letra) :
                new ObjectParameter("letra", typeof(string));
    
            var folioParameter = folio != null ?
                new ObjectParameter("folio", folio) :
                new ObjectParameter("folio", typeof(string));
    
            var sexoParameter = sexo.HasValue ?
                new ObjectParameter("sexo", sexo) :
                new ObjectParameter("sexo", typeof(bool));
    
            var fechaAltaParameter = fechaAlta.HasValue ?
                new ObjectParameter("fechaAlta", fechaAlta) :
                new ObjectParameter("fechaAlta", typeof(System.DateTime));
    
            var idUsuarioAltaParameter = idUsuarioAlta.HasValue ?
                new ObjectParameter("idUsuarioAlta", idUsuarioAlta) :
                new ObjectParameter("idUsuarioAlta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("EFinsertPersona", idTipoPersonaParameter, apellidoParameter, nombreParameter, idTipoDocumentoParameter, cuitParameter, numeroDocumentoParameter, idEstadoCivilParameter, nacionalidadParameter, idTipoSociedadParameter, tipoPersoneriaParameter, registroParameter, numeroSociedadParameter, fechaInscripcionParameter, tomoParameter, letraParameter, folioParameter, sexoParameter, fechaAltaParameter, idUsuarioAltaParameter);
        }
    
        public virtual int EFUpdatePersona(Nullable<int> id, Nullable<int> idTipoPersona, string apellido, string nombre, Nullable<int> idTipoDocumento, string cuit, Nullable<decimal> numeroDocumento, Nullable<int> idEstadoCivil, string nacionalidad, Nullable<int> idTipoSociedad, string tipoPersoneria, string registro, string numeroSociedad, string fechaInscripcion, string tomo, string letra, string folio, Nullable<bool> sexo, Nullable<System.DateTime> fechaAlta, Nullable<int> idUsuarioAlta)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var idTipoPersonaParameter = idTipoPersona.HasValue ?
                new ObjectParameter("idTipoPersona", idTipoPersona) :
                new ObjectParameter("idTipoPersona", typeof(int));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("apellido", apellido) :
                new ObjectParameter("apellido", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var idTipoDocumentoParameter = idTipoDocumento.HasValue ?
                new ObjectParameter("idTipoDocumento", idTipoDocumento) :
                new ObjectParameter("idTipoDocumento", typeof(int));
    
            var cuitParameter = cuit != null ?
                new ObjectParameter("cuit", cuit) :
                new ObjectParameter("cuit", typeof(string));
    
            var numeroDocumentoParameter = numeroDocumento.HasValue ?
                new ObjectParameter("numeroDocumento", numeroDocumento) :
                new ObjectParameter("numeroDocumento", typeof(decimal));
    
            var idEstadoCivilParameter = idEstadoCivil.HasValue ?
                new ObjectParameter("idEstadoCivil", idEstadoCivil) :
                new ObjectParameter("idEstadoCivil", typeof(int));
    
            var nacionalidadParameter = nacionalidad != null ?
                new ObjectParameter("nacionalidad", nacionalidad) :
                new ObjectParameter("nacionalidad", typeof(string));
    
            var idTipoSociedadParameter = idTipoSociedad.HasValue ?
                new ObjectParameter("idTipoSociedad", idTipoSociedad) :
                new ObjectParameter("idTipoSociedad", typeof(int));
    
            var tipoPersoneriaParameter = tipoPersoneria != null ?
                new ObjectParameter("tipoPersoneria", tipoPersoneria) :
                new ObjectParameter("tipoPersoneria", typeof(string));
    
            var registroParameter = registro != null ?
                new ObjectParameter("registro", registro) :
                new ObjectParameter("registro", typeof(string));
    
            var numeroSociedadParameter = numeroSociedad != null ?
                new ObjectParameter("numeroSociedad", numeroSociedad) :
                new ObjectParameter("numeroSociedad", typeof(string));
    
            var fechaInscripcionParameter = fechaInscripcion != null ?
                new ObjectParameter("fechaInscripcion", fechaInscripcion) :
                new ObjectParameter("fechaInscripcion", typeof(string));
    
            var tomoParameter = tomo != null ?
                new ObjectParameter("tomo", tomo) :
                new ObjectParameter("tomo", typeof(string));
    
            var letraParameter = letra != null ?
                new ObjectParameter("letra", letra) :
                new ObjectParameter("letra", typeof(string));
    
            var folioParameter = folio != null ?
                new ObjectParameter("folio", folio) :
                new ObjectParameter("folio", typeof(string));
    
            var sexoParameter = sexo.HasValue ?
                new ObjectParameter("sexo", sexo) :
                new ObjectParameter("sexo", typeof(bool));
    
            var fechaAltaParameter = fechaAlta.HasValue ?
                new ObjectParameter("fechaAlta", fechaAlta) :
                new ObjectParameter("fechaAlta", typeof(System.DateTime));
    
            var idUsuarioAltaParameter = idUsuarioAlta.HasValue ?
                new ObjectParameter("idUsuarioAlta", idUsuarioAlta) :
                new ObjectParameter("idUsuarioAlta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EFUpdatePersona", idParameter, idTipoPersonaParameter, apellidoParameter, nombreParameter, idTipoDocumentoParameter, cuitParameter, numeroDocumentoParameter, idEstadoCivilParameter, nacionalidadParameter, idTipoSociedadParameter, tipoPersoneriaParameter, registroParameter, numeroSociedadParameter, fechaInscripcionParameter, tomoParameter, letraParameter, folioParameter, sexoParameter, fechaAltaParameter, idUsuarioAltaParameter);
        }
    }
}
