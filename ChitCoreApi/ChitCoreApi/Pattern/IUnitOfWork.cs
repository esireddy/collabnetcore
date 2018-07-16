using ChitCoreApi.ChitMgmt.Pattern;
using ChitCoreApi.Users.Pattern;
using System;

namespace ChitCoreApi.Pattern
{
    public interface IUnitOfWork : IDisposable
    {
        IChitRepository Chits { get; }

        IUserRepository Users { get; }

        bool Complete();
    }
}
