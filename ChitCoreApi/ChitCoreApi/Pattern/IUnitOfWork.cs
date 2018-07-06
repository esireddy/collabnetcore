using ChitCoreApi.ChitMgmt.Pattern;
using System;

namespace ChitCoreApi.Pattern
{
    public interface IUnitOfWork : IDisposable
    {
        IChitRepository Chits { get; }

        bool Complete();
    }
}
