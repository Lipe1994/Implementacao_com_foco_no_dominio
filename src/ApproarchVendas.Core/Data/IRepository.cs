using ApproarchVendas.Core.Contracts;
using System;

namespace ApproarchVendas.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
