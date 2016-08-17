using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    class UsuarioModel
    {
        public int id { get; set; }
        public byte[] sid { get; set; }
        public string apellido { get; set; }
        public string nombres { get; set; }
        public Nullable<int> idTipoUsuario { get; set; }
        public Nullable<int> idSubsecretaria { get; set; }
        public Nullable<bool> activo { get; set; }
        public string motivoBaja { get; set; }
        public bool crearADUser { get; set; }
        public Nullable<System.DateTime> ultimoLogin { get; set; }
        public Nullable<System.DateTime> ultimoLogout { get; set; }
        public Nullable<System.DateTime> fechaBaja { get; set; }
        public string userName { get; set; }
        public Nullable<int> idUsuarioBaja { get; set; }
        public string codigoSeguridad { get; set; }
        public string tratamiento { get; set; }
    }
}
