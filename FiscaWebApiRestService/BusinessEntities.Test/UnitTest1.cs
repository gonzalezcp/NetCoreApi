using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessEntities.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PersonaModelTest()
        {
            var p = new PersonaModel()
            {
                apellido = "In the Brain",
                nombre = "Insane",
                numeroDocumento = 1,
                cuit = "20-22255555-1",
                idTipoPersona = 1,
                idTipoDocumento = 1,
                idTipoSociedad = null,
                nacionalidad = "Argentino"
            };

            var p2 = new PersonaModel()
            {
                apellido = "In the Brain",
                nombre = "Insane",
                numeroDocumento = 1,
                cuit = "20-22255555-1",
                idTipoPersona = 1,
                idTipoDocumento = 1,
                idTipoSociedad = null,
                nacionalidad = "Chino"
            };

            var p3 = new PersonaModel()
            {
                apellido = "Otro",
                nombre = "Ñoño",
                numeroDocumento = 1,
                cuit = "20-22255665-1",
                idTipoPersona = 1,
                idTipoDocumento = 1,
                idTipoSociedad = 1,
                nacionalidad = "No se"
            };
            Assert.AreEqual<PersonaModel>(p,p2);

        }
    }
}
