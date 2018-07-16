using ChitCoreApi.Data;
using ChitCoreApi.Pattern;
using ChitCoreApi.Users.post.v1.Models;
using System.Collections.Generic;
using System.Linq;

namespace ChitCoreApi.Users.Pattern
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        #region Constructors

        public UserRepository(ChitDbContext dbContext) : base(dbContext) { }

        #endregion Constructors

        #region Properties

        public ChitDbContext ChitDbContext
        {
            get
            {
                return dbContext as ChitDbContext;
            }
        }

        #endregion Properties

        #region Methods

        public IEnumerable<User> Get(string searchTerm)
        {
            return dbContext.Set<User>().ToList()
                .Where(user => user.Lastname.ToLower().StartsWith(searchTerm.ToLower()));
        }

        #endregion Methods
    }
}
