using ChitCore.Data.v1.Models;
using System.Collections.Generic;

namespace ChitCore.Data.v1
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> Get(string searchTerm);
        IEnumerable<Chit> GetUserChits(int userId);
    }
}
