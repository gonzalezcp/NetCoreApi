using BusinessEntities;
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
            foreach (PersonaModel p in personas)
            {
                Console.WriteLine(p.apellido + ", " + p.nombre);
            }
            //using (var context = new DataModel.fiscaliaEntities())
            //{
            //    var pesonas = (from p in context.personas where p.apellido == "Gonzalez" select p).ToList();
            //    foreach (var p in pesonas)
            //    {
            //        Console.WriteLine(p.apellido + ", " + p.nombre);
            //    }
            //}


        }
    }
}
