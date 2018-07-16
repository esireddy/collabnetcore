using ChitCoreApi.Pattern;
using ChitCoreApi.Users.post.v1.Models;
using System.Collections.Generic;

namespace ChitCoreApi.Users.Pattern
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> Get(string searchTerm);
    }
}
