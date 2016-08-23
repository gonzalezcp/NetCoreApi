using BusinessEntities;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAMano
{
    class Program
    {
        static void Main(string[] args)
        {
            var servicio = new DataModel.Service.EntityFrameworkService<DataModel.fiscaliaEntities>(new DataModel.fiscaliaEntities());
            //var personas = servicio.GetPersonaApellido("Gonzalez");
            //foreach (PersonaModel p in personas)
            //{
            //    Console.WriteLine(p.apellido + ", " + p.nombre);
            //}

            var personaNueva = new PersonaModel
            {
                id = 3,
                nombre = "Loco",
                apellido = "Del Coco",
                sexo = true,
                numeroDocumento = 66666
            };
            //int idPersonaNueva = servicio.CreatePersonas(personaNueva);

            //var ape = servicio.GetPersonaApellido("Del Coco");
            bool wasDeleted = servicio.DeletePersonaById(638282);

        }
    }
}
