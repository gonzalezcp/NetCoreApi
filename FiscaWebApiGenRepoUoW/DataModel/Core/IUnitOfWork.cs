using DataModel.Core.Repositories;
using System;

namespace DataModel.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        int Complete();
    }
}