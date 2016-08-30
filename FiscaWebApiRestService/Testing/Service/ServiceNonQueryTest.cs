using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataModel;
using DataModel.Service;
using Moq;
using System.Data.Entity;
using BusinessEntities;
using System.Collections.Generic;

namespace DataModel.Test.Service
{
    [TestClass]
    public class ServiceNonQueryTest
    {
        [TestMethod]
        public void CreatePersonas()
        {
            var mockSet = new Mock<DbSet<persona>>();
            var mockContext = new Mock<fiscaliaEntities>();
            mockContext.Setup(m => m.personas).Returns(mockSet.Object);
            mockContext.Setup(m => m.Set<persona>()).Returns(mockSet.Object);

            var service = new EntityFrameworkService<DataModel.fiscaliaEntities>(mockContext.Object);
            var personaNueva = new PersonaModel
            {
                nombre = "Loco",
                apellido = "Del Coco",
                sexo = true,
                numeroDocumento = 66666
            };
            int idPersonaNueva = service.CreatePersonas(personaNueva);

            // test verifies that the service added a new Persona
            mockSet.Verify(m => m.Add(It.IsAny<persona>()), Times.Once());

            // test that service called SaveChanges on the context
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

    }
}
