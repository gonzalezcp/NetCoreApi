using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class PersonaModel : IComparable
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

        public int CompareTo(object obj)
        {
            if (sortPersonAsendiendo().Compare(this, obj) > 1)
                return 1;
            else
            if (sortPersonAsendiendo().Compare(this, obj) < 1)
                return -1;
            else return 0;

        }

        public override bool Equals(object obj)
        {
            return ((String.Compare(this.apellido, ((PersonaModel)obj).apellido) == 0) &&
                (String.Compare(this.nombre, ((PersonaModel)obj).nombre) == 0) &&
                (this.numeroDocumento == ((PersonaModel)obj).numeroDocumento) &&
                (String.Compare(this.cuit, ((PersonaModel)obj).cuit) == 0) &&
                (this.idTipoPersona == ((PersonaModel)obj).idTipoPersona) &&
                (this.idTipoDocumento == ((PersonaModel)obj).idTipoDocumento) &&
                (this.idTipoSociedad == ((PersonaModel)obj).idTipoSociedad));
        }


        public static IComparer sortPersonAsendiendo()
        {
            return (IComparer)new sortPersonaByApellidoNombreHelper();
        }

        private class sortPersonaByApellidoNombreHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                PersonaModel p1 = (PersonaModel)a;
                PersonaModel p2 = (PersonaModel)b;

                if (String.Compare(p1.apellido, p2.apellido) <1)
                    return 1;

                if (String.Compare(p1.apellido, p2.apellido) > 1)
                    return -1;

                else
                {
                    if (String.Compare(p1.nombre, p2.nombre) < 1)
                        return 1;

                    if (String.Compare(p1.nombre, p2.nombre) > 1)
                        return -1;
                    else
                        return 0;
                }

            }
        }
    }
}
