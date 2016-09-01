using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiscaWebApiRestService.Controllers;
using DataModel;
using DataModel.Service;
using Moq;
using BusinessEntities;
using System.Net;
using Newtonsoft.Json;
using System.Data.Entity;

namespace FiscaWebApiRestService.Tests.Controllers
{
    [TestClass]
    public class PersonaControllerTest
    {
        private Mock<fiscaliaEntities> mockContext;
        private EntityFrameworkService<DataModel.fiscaliaEntities> entityFrameworkService;
        private Mock<DbSet<EFPersona>> mockSet;

        public PersonaControllerTest()
        {
            List<EFPersona> table = new List<EFPersona>();
            mockSet = EFMockHelper<EFPersona, fiscaliaEntities>.getMockedSet(table);
            mockContext = new Mock<fiscaliaEntities>();
            mockContext.Setup(c => c.EFPersonas).Returns(mockSet.Object);
            // este es porque el Servicio usa Genericos
            mockContext.Setup(m => m.Set<EFPersona>()).Returns(mockSet.Object);
            mockContext.Object.EFPersonas.Add(
            new EFPersona
            {
                id = 1,
                nombre = "Loco",
                apellido = "Del Coco",
                sexo = true,
                numeroDocumento = 66666
            });
            mockContext.Object.EFPersonas.Add(
            new EFPersona
            {
                id = 2,
                nombre = "Chiflado",
                apellido = "Del Coco",
                sexo = true,
                numeroDocumento = 66666
            });

            //Test
            entityFrameworkService = new EntityFrameworkService<DataModel.fiscaliaEntities>(mockContext.Object);


        }

        [TestMethod]
        public void GetPersonaControllerTest()
        {
            // Arrange
            var controller = new PersonaController(entityFrameworkService);
            Helper.SetupControllerForTests(controller, HttpMethod.Get, "Persona");
            var response = controller.Get();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode); // Check the HTTP status
            var responseString = response.Content.ReadAsStringAsync().Result;
            var jsonObject = JsonConvert.DeserializeObject<List<PersonaModel>>(responseString);
            Assert.AreEqual(jsonObject.Any(), true);
            //chequeo que esten todas las propiedades
            string nombre = jsonObject[0].nombre;
            Assert.AreEqual(nombre, "Loco");
        }

        [TestMethod]
        public void PostPersonaControllerTest()
        {
            var controller = new PersonaController(entityFrameworkService);
            Helper.SetupControllerForTests(controller, HttpMethod.Post, "Persona");
            var personaNueva = new PersonaModel
            {
                nombre = "Loco",
                apellido = "Del Mierda",
                sexo = true,
                numeroDocumento = 66666
            };
            var response = controller.Post(personaNueva);

            //// Assert
            //este no anda porque no crea la identidad en memoria falta algo del mock
            Assert.AreEqual(personaNueva.apellido, mockContext.Object.EFPersonas.Last().apellido);
        }

        [TestMethod]
        public void PutControllerTest()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void DeleteControllerTest()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}

