using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAMano
{
    public class Helper
    {
        
        public void insertarPersona()
        {
            //create DBContext object
            var personaNueva = new EFPersona
            {
                nombre = "Loco",
                apellido = "Del Coco",
                sexo = true,
                numeroDocumento = 66666
            };
            using (var context = new DataModel.fiscaliaEntities())
            {
                context.EFPersonas.Add(personaNueva);
                context.SaveChanges();
            }
        }

        public void listarPersonasQuery()
        {
            using (var context = new DataModel.fiscaliaEntities())
            {
                var pesonas = (from p in context.EFPersonas where p.apellido == "Gonzalez" select p).ToList();
                foreach (var p in pesonas)
                {
                    Console.WriteLine(p.apellido + ", " + p.nombre);
                }
            }
        }

    }
}
