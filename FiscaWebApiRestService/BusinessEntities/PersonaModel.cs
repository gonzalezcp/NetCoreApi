using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class PersonaModel
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
