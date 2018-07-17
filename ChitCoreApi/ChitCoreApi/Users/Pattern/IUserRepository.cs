using ChitCoreApi.ChitMgmt.post.v1.Models;
using ChitCoreApi.Pattern;
using System.Collections.Generic;

namespace ChitCoreApi.Users.Pattern
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> Get(string searchTerm);
        IEnumerable<Chit> GetUserChits(int userId);
    }
}
