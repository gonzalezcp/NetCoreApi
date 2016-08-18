using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ColaDistribucionLogModel
    {
        public int id { get; set; }
        public Nullable<int> idColaDistribucion { get; set; }
        public Nullable<int> idJuicio { get; set; }
        public Nullable<decimal> montoJuicio { get; set; }
        public Nullable<decimal> montoPromedio { get; set; }
        public Nullable<int> puntajeRestante { get; set; }
        public Nullable<int> puntajeRestado { get; set; }
        public Nullable<int> puntajeRestanteActualizado { get; set; }
        public Nullable<bool> habilitado { get; set; }
        public Nullable<int> pasada { get; set; }
        public Nullable<int> posicionActual { get; set; }
        public Nullable<int> puntajeApoderado { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string numeroTitulo { get; set; }
        public Nullable<int> idTipoEvento { get; set; }

        public virtual ColaDistribucionModel colaDistribucion { get; set; }
    }
}
