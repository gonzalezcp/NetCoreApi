using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessEntities;
using System.Collections.Generic;
using System.Linq;
using DataModel;
using System.Data.Entity;
using Moq;
using DataModel.Service;

namespace DataModel.Test.Service
{
    [TestClass]
    public class ServiceQueryTest
    {
        private Mock<fiscaliaEntities> mockContext;
        private EntityFrameworkService<DataModel.fiscaliaEntities> service;
        private Mock<DbSet<EFPersona>> mockSet;
        public ServiceQueryTest()
        {
            var table = new List<EFPersona>();
            mockSet = EFMockHelper<EFPersona, fiscaliaEntities>.getMockedSet(table);
            mockContext = new Mock<fiscaliaEntities>();
            mockContext.Setup(c => c.EFPersonas).Returns(mockSet.Object);
            // este es porque el Servicio usa Genericos
            mockContext.Setup(m => m.Set<EFPersona>()).Returns(mockSet.Object);
            service = new EntityFrameworkService<DataModel.fiscaliaEntities>(mockContext.Object);
        }

        [TestMethod]
        public void GetPersonaApellidoService()
        {
            mockContext.Object.EFPersonas.Add(
            new EFPersona
            {
                nombre = "Loco",
                apellido = "Del Coco",
                sexo = true,
                numeroDocumento = 66666
            });

            mockContext.Object.EFPersonas.Add(
            new EFPersona
            {
                nombre = "Chiflado",
                apellido = "Del Coco",
                sexo = true,
                numeroDocumento = 66666
            });

            var personasQuery = service.GetPersonaApellido("Del Coco");
            Assert.AreEqual(2, personasQuery.Count());
        }

        [TestMethod]
        public void TestMockSet()
        {
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
            Assert.AreEqual(2, mockContext.Object.EFPersonas.Count());
            //delete
            bool wasDeleted = service.DeletePersonaById(1);
            //cheque que fueron borradas
            mockSet.Verify(x => x.Remove(It.IsAny<EFPersona>()));
            Assert.AreEqual(1, mockContext.Object.EFPersonas.Count());
        }

        [TestMethod]
        public void DeletePersonaService()
        {
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

            Assert.AreEqual(2, mockContext.Object.EFPersonas.Count());
            bool wasDeleted = service.DeletePersonaById(1);
            //delete
            Assert.AreEqual(1, mockContext.Object.EFPersonas.Count());
        }

        [TestMethod]
        public void UpdatePersonaService()
        {
            mockContext.Object.EFPersonas.Add(
            new EFPersona
            {
                id = 37,
                nombre = "Loco",
                apellido = "Del Coco",
                sexo = true,
                numeroDocumento = 66666
            });

            var personaModel = new PersonaModel
            {
                id = 37,
                nombre = "Loco modificado",
                apellido = "Del Coco PUTO",
                sexo = true,
                numeroDocumento = 66666
            };
            bool wasDeleted = service.UpdatePersona(37, personaModel);
            var nombre = mockContext.Object.EFPersonas.Select(p => p.nombre).FirstOrDefault();
            Assert.AreEqual("Loco modificado", nombre);
        }

        [TestMethod]
        public void CreatePersonasService()
        {
            ////Test

            int idPersonaNueva = service.CreatePersonas(
            new PersonaModel
            {
                id = 189,
                nombre = "Loco",
                apellido = "Del Coco",
                sexo = true,
                numeroDocumento = 66666
            });
            int idInsert = mockContext.Object.EFPersonas.Select(p => p.id).FirstOrDefault();
            Assert.AreEqual(189, idInsert);
            Assert.AreEqual(1, mockContext.Object.EFPersonas.Count());
        }

    }
}
