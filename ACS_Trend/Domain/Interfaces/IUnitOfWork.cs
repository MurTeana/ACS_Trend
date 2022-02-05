using System;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUnitRepository Units { get; }
        // other repos
        int Complete();
    }
}
