//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class persona
    {
        public int id { get; set; }
        public Nullable<int> idTipoPersona { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public Nullable<int> idTipoDocumento { get; set; }
        public string cuit { get; set; }
        public Nullable<decimal> numeroDocumento { get; set; }
        public Nullable<int> idEstadoCivil { get; set; }
        public string nacionalidad { get; set; }
        public Nullable<int> idTipoSociedad { get; set; }
        public string tipoPersoneria { get; set; }
        public string registro { get; set; }
        public string numeroSociedad { get; set; }
        public string fechaInscripcion { get; set; }
        public string tomo { get; set; }
        public string letra { get; set; }
        public string folio { get; set; }
        public Nullable<bool> sexo { get; set; }
        public Nullable<System.DateTime> fechaAlta { get; set; }
        public Nullable<int> idUsuarioAlta { get; set; }
        public string razonSocial { get; set; }
    }
}
