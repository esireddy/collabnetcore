using ChitCore.Data.v1;
using ChitCore.Data.v1.Models;
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
                .Where(user => user.LastName.ToLower().StartsWith(searchTerm.ToLower()));
        }

        public IEnumerable<Chit> GetUserChits(int userId)
        {
            //var userChits = ChitDbContext.Chits
            //    .Include(cu => cu.ChitUsers)
            //    .Where(cu => cu.ChitUsers.Any(x => x.UserId == userId))
            //    .ToList();

            var userChits = ChitDbContext.Users
                    .Where(x => x.Id == userId)
                    .SelectMany(uc => uc.ChitUsers)
                    .Select(uc => uc.Chit);

            return userChits.ToList();
        }

        #endregion Methods
    }
}
