using System;

namespace ACS_Trend.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUnitRepository Units { get; }
        // other repos
        int Complete();
    }
}
