using ChitCoreApi.ChitMgmt.post.v1.Models;
using ChitCoreApi.Data;
using ChitCoreApi.Pattern;

namespace ChitCoreApi.ChitMgmt.Pattern
{
    public class ChitRepository : Repository<Chit>, IChitRepository
    {
        #region Constructors

        public ChitRepository(ChitDbContext dbContext) : base(dbContext) { }

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
    }
}
