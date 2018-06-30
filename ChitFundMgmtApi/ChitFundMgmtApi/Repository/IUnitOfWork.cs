using ChitFundMgmtApi.ChitMgmt.Repository;
using System;

namespace ChitFundMgmtApi.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IChitRepository Chits { get; }
        bool Complete();
    }
}
