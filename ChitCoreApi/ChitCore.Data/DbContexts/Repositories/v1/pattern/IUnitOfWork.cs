using ChitCoreApi.Users.Pattern;
using System;

namespace ChitCore.Data.v1
{
    public interface IUnitOfWork : IDisposable
    {
        IChitRepository Chits { get; }

        IUserRepository Users { get; }

        bool Complete();
    }
}
