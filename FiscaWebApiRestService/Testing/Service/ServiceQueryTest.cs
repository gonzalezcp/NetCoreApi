using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessEntities;
using System.Collections.Generic;
using System.Linq;
using DataModel;
using System.Data.Entity;
using Moq;
using DataModel.Service;

namespace Testing.Service
{
    [TestClass]
    public class ServiceQueryTest
    {

        [TestMethod]
        public void GetPersonaApellido()
        {
            var data = new List<persona>
            {
                new persona
                {
                    nombre = "Loco",
                    apellido = "Del Coco",
                    sexo = true,
                    numeroDocumento = 66666
                },
                new persona
                {
                    nombre = "Chiflado",
                    apellido = "Del Coco",
                    sexo = true,
                    numeroDocumento = 66666
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<persona>>();
            mockSet.As<IQueryable<persona>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<persona>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<persona>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<persona>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<fiscaliaEntities>();
            mockContext.Setup(c => c.personas).Returns(mockSet.Object);
            // este es porque el Servicio usa Genericos
            mockContext.Setup(m => m.Set<persona>()).Returns(mockSet.Object);

            var service = new EntityFrameworkService<DataModel.fiscaliaEntities>(mockContext.Object);
            var personasQuery = service.GetPersonaApellido("Del Coco");
            Assert.AreEqual(2, personasQuery.Count());
        }

        [TestMethod]
        public void DeletePersona()
        {
            var data = new List<persona>
            {
                new persona
                {
                    id = 1,
                    nombre = "Loco",
                    apellido = "Del Coco",
                    sexo = true,
                    numeroDocumento = 66666
                },
                new persona
                {
                    id = 2,
                    nombre = "Chiflado",
                    apellido = "Del Coco",
                    sexo = true,
                    numeroDocumento = 66666
                }
            };
            
            var dataQueryable = data.AsQueryable();

            var mockSet = new Mock<DbSet<persona>>();
            mockSet.As<IQueryable<persona>>().Setup(m => m.Provider).Returns(dataQueryable.Provider);
            mockSet.As<IQueryable<persona>>().Setup(m => m.Expression).Returns(dataQueryable.Expression);
            mockSet.As<IQueryable<persona>>().Setup(m => m.ElementType).Returns(dataQueryable.ElementType);
            mockSet.As<IQueryable<persona>>().Setup(m => m.GetEnumerator()).Returns(dataQueryable.GetEnumerator());
            //mockSet.As<IEnumerable<persona>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<fiscaliaEntities>();
            mockContext.Setup(c => c.personas).Returns(mockSet.Object);
            // este es porque el Servicio usa Genericos
            mockContext.Setup(m => m.Set<persona>()).Returns(mockSet.Object);
            

            //Test
            var service = new EntityFrameworkService<DataModel.fiscaliaEntities>(mockContext.Object);
            //delete
            bool wasDeleted = service.DeletePersonaById(1);
            //cheque que fueron borradas
            mockSet.Verify(x => x.Remove(It.IsAny<persona>()));

            
            
            


















            //// test verifies that the service added a new Persona
            //mockSet.Verify(m => m.Add(It.IsAny<persona>()), Times.Once());

            //// test that service called SaveChanges on the context
            //mockContext.Verify(m => m.SaveChanges(), Times.Once());


        }
    }
}
