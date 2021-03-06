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
    
    public partial class colaDistribucion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public colaDistribucion()
        {
            this.colaDistribucionLogs = new HashSet<colaDistribucionLog>();
        }
    
        public int id { get; set; }
        public int idUsuario { get; set; }
        public int idTipoDistribucion { get; set; }
        public Nullable<int> posicion { get; set; }
        public Nullable<int> puntajeRestante { get; set; }
        public Nullable<bool> habilitado { get; set; }
        public Nullable<int> pasada { get; set; }
        public Nullable<int> posicionActual { get; set; }
        public Nullable<System.DateTime> fechaAlta { get; set; }
        public Nullable<System.DateTime> fechaBorrado { get; set; }
    
        public virtual tiposDistribucione tiposDistribucione { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<colaDistribucionLog> colaDistribucionLogs { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
