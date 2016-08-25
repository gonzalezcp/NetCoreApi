using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data.Entity;

namespace DataModel.Service
{
    public static class EFMockHelper<ListOf, Context>  where ListOf : class where Context : DbContext
    {

        public static Mock<DbSet<ListOf>> getMockedSet(List<ListOf> table)
        {
            //List<ListOf> table = new List<ListOf>();
            var mockSet = new Mock<DbSet<ListOf>>();
            mockSet.As<IQueryable<ListOf>>().Setup(m => m.Provider).Returns(() => table.AsQueryable().Provider);
            mockSet.As<IQueryable<ListOf>>().Setup(m => m.Expression).Returns(() => table.AsQueryable().Expression);
            mockSet.As<IQueryable<ListOf>>().Setup(m => m.ElementType).Returns(() => table.AsQueryable().ElementType);
            mockSet.As<IQueryable<ListOf>>().Setup(m => m.GetEnumerator()).Returns(() => table.AsQueryable().GetEnumerator());

            mockSet.Setup(set => set.Add(It.IsAny<ListOf>())).Callback<ListOf>(table.Add);
            mockSet.Setup(set => set.AddRange(It.IsAny<IEnumerable<ListOf>>())).Callback<IEnumerable<ListOf>>(table.AddRange);
            mockSet.Setup(set => set.Remove(It.IsAny<ListOf>())).Callback<ListOf>(t => table.Remove(t));
            mockSet.Setup(set => set.RemoveRange(It.IsAny<IEnumerable<ListOf>>())).Callback<IEnumerable<ListOf>>(ts =>
            {
                foreach (var t in ts) { table.Remove(t); }
            });

            return mockSet;
        }
    }
}
