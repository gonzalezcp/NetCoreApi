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

namespace FiscaWebApiRestService.Tests.Controllers
{
    [TestClass]
    public class PersonaControllerTest
    {
        private EntityFrameworkService<fiscaliaEntities> entityFrameworkService;

        public PersonaControllerTest()
        {
            List<persona> table = new List<persona>();
            var mockSet = EFMockHelper<persona, fiscaliaEntities>.getMockedSet(table);
            var mockContext = new Mock<fiscaliaEntities>();
            mockContext.Setup(c => c.personas).Returns(mockSet.Object);
            // este es porque el Servicio usa Genericos
            mockContext.Setup(m => m.Set<persona>()).Returns(mockSet.Object);
            mockContext.Object.personas.Add(
            new persona
            {
                id = 1,
                nombre = "Loco",
                apellido = "Del Coco",
                sexo = true,
                numeroDocumento = 66666
            });
            mockContext.Object.personas.Add(
            new persona
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

        //[TestMethod]
        //public void GetPersonaByIdControllerTest()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    string result = controller.Get(5);

        //    // Assert
        //    Assert.AreEqual("value", result);
        //}

        [TestMethod]
        public void PostControllerTest()
        {
            // Arrange
            ValuesController controller = new ValuesController();
            // Act
            controller.Post("value");
            // Assert
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

