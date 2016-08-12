using DataModel;
using DataModel.Persistence;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new WebApiDbEntities()))
            {
                // Example1
                var product = unitOfWork.Products.Get(1);

                unitOfWork.Complete();
            }
        }
    }
}
  