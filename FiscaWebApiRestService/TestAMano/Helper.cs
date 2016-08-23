﻿using DataModel;
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
            var personaNueva = new persona
            {
                nombre = "Loco",
                apellido = "Del Coco",
                sexo = true,
                numeroDocumento = 66666
            };
            using (var context = new DataModel.fiscaliaEntities())
            {
                context.personas.Add(personaNueva);
                context.SaveChanges();
            }
        }

        public void listarPersonasQuery()
        {
            using (var context = new DataModel.fiscaliaEntities())
            {
                var pesonas = (from p in context.personas where p.apellido == "Gonzalez" select p).ToList();
                foreach (var p in pesonas)
                {
                    Console.WriteLine(p.apellido + ", " + p.nombre);
                }
            }
        }

    }
}
