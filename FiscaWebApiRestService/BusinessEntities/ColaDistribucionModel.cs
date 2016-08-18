using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ColaDistribucionModel
    {

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

    }
}
