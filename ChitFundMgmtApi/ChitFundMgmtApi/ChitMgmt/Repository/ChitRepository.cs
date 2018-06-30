using ChitFundMgmtApi.ChitMgmt.Post.v1.Entities;
using ChitFundMgmtApi.Data;
using ChitFundMgmtApi.Repository;

namespace ChitFundMgmtApi.ChitMgmt.Repository
{
    public class ChitRepository : Repository<Chit>, IChitRepository
    {
        #region Constructors
        public ChitRepository(ChitDbContext _dbContext) : base(_dbContext)
        {

        }
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
