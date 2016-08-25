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
        public void TestMockSet()
        {
            List<persona> table = new List<persona>();

            //var mockSet = new Mock<DbSet<persona>>();
            //mockSet.As<IQueryable<persona>>().Setup(m => m.Provider).Returns(() => table.AsQueryable().Provider);
            //mockSet.As<IQueryable<persona>>().Setup(m => m.Expression).Returns(() => table.AsQueryable().Expression);
            //mockSet.As<IQueryable<persona>>().Setup(m => m.ElementType).Returns(() => table.AsQueryable().ElementType);
            //mockSet.As<IQueryable<persona>>().Setup(m => m.GetEnumerator()).Returns(() => table.AsQueryable().GetEnumerator());

            //mockSet.Setup(set => set.Add(It.IsAny<persona>())).Callback<persona>(table.Add);
            //mockSet.Setup(set => set.AddRange(It.IsAny<IEnumerable<persona>>())).Callback<IEnumerable<persona>>(table.AddRange);
            //mockSet.Setup(set => set.Remove(It.IsAny<persona>())).Callback<persona>(t => table.Remove(t));
            //mockSet.Setup(set => set.RemoveRange(It.IsAny<IEnumerable<persona>>())).Callback<IEnumerable<persona>>(ts =>
            //{
            //    foreach (var t in ts) { table.Remove(t); }
            //});

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
            var service = new EntityFrameworkService<DataModel.fiscaliaEntities>(mockContext.Object);
            //delete
            bool wasDeleted = service.DeletePersonaById(1);
            //cheque que fueron borradas
            mockSet.Verify(x => x.Remove(It.IsAny<persona>()));
            Assert.AreEqual(1, table.Count());
        }

        [TestMethod]
        public void DeletePersona2()
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
            var service = new EntityFrameworkService<DataModel.fiscaliaEntities>(mockContext.Object);

            //delete
            bool wasDeleted = service.DeletePersonaById(1);
            Assert.AreEqual(1, table.Count());
        }

    }
}
