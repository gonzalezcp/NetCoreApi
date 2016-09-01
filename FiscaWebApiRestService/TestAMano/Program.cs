using BusinessEntities;
using DataModel;
using DataModel.Service;
using Moq;
using Ninject;
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
            var personas = servicio.GetPersonaApellido("Gonzalez");
            //foreach (PersonaModel p in personas)
            //{
            //    Console.WriteLine(p.apellido + ", " + p.nombre);
            //}

            //var personaNueva = new PersonaModel
            //{
            //    id = 3,
            //    nombre = "Loco",
            //    apellido = "Del Coco",
            //    sexo = true,
            //    numeroDocumento = 66666
            //};
            //int idPersonaNueva = servicio.CreatePersonas(personaNueva);

            //var ape = servicio.GetPersonaApellido("Del Coco");
            //bool wasDeleted = servicio.DeletePersonaById(638282);

            ////ninject
            //Ninject.IKernel kernal = new StandardKernel();
            //kernal.Bind<IService>().To<EntityFrameworkService<fiscaliaEntities>>();
            //var instance = kernal.Get<EntityFrameworkService<fiscaliaEntities>>();
            //instance.GetPersonaApellido("Del Coco");
            //Console.ReadLine();

            List<EFPersona> table = new List<EFPersona>();
            var mockSet = EFMockHelper<EFPersona, fiscaliaEntities>.getMockedSet(table);
            var mockedDbContext = new Mock<fiscaliaEntities>();
            mockedDbContext.Setup(c => c.EFPersonas).Returns(mockSet.Object);
            // este es porque el Servicio usa Genericos
            mockedDbContext.Setup(m => m.Set<EFPersona>()).Returns(mockSet.Object);

            mockedDbContext.Object.EFPersonas.Add(
            new EFPersona
            {
                id = 1,
                nombre = "Loco",
                apellido = "Del Coco",
                sexo = true,
                numeroDocumento = 66666
            });
            mockedDbContext.Object.EFPersonas.Add(
            new EFPersona
            {
                id = 2,
                nombre = "Chiflado",
                apellido = "Del Coco",
                sexo = true,
                numeroDocumento = 66666
            });
            //Test
            var service = new EntityFrameworkService<DataModel.fiscaliaEntities>(mockedDbContext.Object);
            //delete
            bool wasDeleted = service.DeletePersonaById(1);
        }
    }
}
