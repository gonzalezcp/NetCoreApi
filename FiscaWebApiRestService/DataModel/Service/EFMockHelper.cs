using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Service
{
    public class EFMockHelper<T> 
    {
        public static MockedDbContext<T> GetMockContext<T>() where T : DbContext
        {
            //var instance = new MockedDbContext<T>();
            //instance.MockTables();
            List<persona> table = new List<persona>();
            var mockSet = new Mock<DbSet<persona>>();
            return new MockedDbContext<T>();
        }
        

    }

}
