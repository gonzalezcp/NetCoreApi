using DataModel;
using DataModel.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var unitOfWork = new UnitOfWork(new WebApiDbEntities()))
            //{
            //    // Example1
            //    var product = unitOfWork.Products.Get(1);
            //    var users = unitOfWork.User.GetAll();
            //    unitOfWork.Complete();
            //    foreach (User u in users)
            //    {
            //        Console.WriteLine(u.Name); 
            //    }
            //}
            //using (var dbconetex = new WebApiDbEntities())
            //{
            //    Console.WriteLine(dbconetex.Products.SingleOrDefault(a => a.ProductId == 1));
            //}
        }
    }
}
