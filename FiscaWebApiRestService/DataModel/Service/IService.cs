using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Service
{
    public interface IService
    {
        IEnumerable<colaDistribucion> GetCola();
        IEnumerable<BusinessEntities.PersonaModel> GetPersonaApellido(String apellido);
    }

}
