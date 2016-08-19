using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    class JuicioModel
    {
        public int id { get; set; }
        public Nullable<System.DateTime> fechaAlta { get; set; }
        public Nullable<System.DateTime> fechaRadicacion { get; set; }
        public string caratula { get; set; }
        public Nullable<int> idMateria { get; set; }
        public Nullable<decimal> montoOriginal { get; set; }
        public int idSubsecretaria { get; set; }
        public string juzgado { get; set; }
        public Nullable<int> idJuzgado { get; set; }
        public Nullable<int> secretariaJuzgado { get; set; }
        public string expedienteJudicial { get; set; }
        public Nullable<int> idDepartamentoJudicial { get; set; }
        public Nullable<int> idPartido { get; set; }
        public Nullable<decimal> montoSentencia { get; set; }
        public Nullable<int> idOrigenDeuda { get; set; }
        public Nullable<bool> activo { get; set; }
        public Nullable<bool> evalua { get; set; }
        public int idEstadoJuicio { get; set; }
        public bool heredado { get; set; }
        public Nullable<System.DateTime> fechaCambioEstado { get; set; }
        public Nullable<int> idDependenciaOrigen { get; set; }
        public Nullable<int> idReparticion { get; set; }
        public Nullable<System.DateTime> fechaBorrado { get; set; }
        public string motivoBorrado { get; set; }
        public Nullable<int> idUsuarioBorrado { get; set; }
        public Nullable<int> idTipoJuicio { get; set; }
        public Nullable<int> idLocalidadEco { get; set; }
        public bool esperaRadicacionSCBA { get; set; }
        public Nullable<int> idTipoDistribucion { get; set; }
        public Nullable<bool> signed { get; set; }
        public Nullable<int> idNuevoEstado { get; set; }
    }
}
