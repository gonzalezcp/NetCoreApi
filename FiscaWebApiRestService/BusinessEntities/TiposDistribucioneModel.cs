using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class TiposDistribucioneModel
    {

        public int id { get; set; }
        public string tipoDistribucion { get; set; }
        public Nullable<decimal> montoPromedio { get; set; }
        public Nullable<bool> distribucionPorCola { get; set; }

    }
}
