using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiscaWebApiRestService;
using FiscaWebApiRestService.Controllers;
using DataModel;
using DataModel.Service;
using Moq;
using BusinessEntities;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Web.Http.Results;
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

            table.Add(
            new persona
            {
                id = 1,
                nombre = "Loco",
                apellido = "Del Coco",
                sexo = true,
                numeroDocumento = 66666
            });
            table.Add(
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
        public void GetPersoanJsonFormat()
        {
            // Arrange
            var controller = new PersonaController(entityFrameworkService);

            // Act
            var response = controller.Get();

            // Assert
            //dynamic jsonObject = JObject.Parse(result.ToString());
            var responseResult = JsonConvert.DeserializeObject<List<PersonaModel>>(response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode); // Check the HTTP status
            Assert.AreEqual(responseResult.Any(), true);
            //var comparer = new ProductComparer();
            //CollectionAssert.AreEqual(
            //    responseResult.OrderBy(product => product, comparer),
            //    _products.OrderBy(product => product, comparer), comparer);

            //Assert.Equal(status, 0);
            //Assert.AreEqual(10, personaModel.id);
            //Assert.AreEqual("value1", result.ElementAt(0));
            //Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Post("value");

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
