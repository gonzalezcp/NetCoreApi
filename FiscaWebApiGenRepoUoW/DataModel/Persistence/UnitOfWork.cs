using DataModel;
using DataModel.Core;
using DataModel.Core.Repositories;
using DataModel.Persistence.Repositories;
using System;

namespace DataModel.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebApiDbEntities _context;

        public UnitOfWork(WebApiDbEntities context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            //Authors = new AuthorRepository(_context);
            User = new Repository<User>(_context);
        }


        //public IProdcutRepository Courses { get; private set; }
        //public IAuthorRepository Authors { get; private set; }
        public IProductRepository Products { get; private set; }
        public IRepository<User> User { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}