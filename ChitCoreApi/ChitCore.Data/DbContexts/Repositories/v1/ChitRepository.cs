using ChitCore.Data.v1.Models;

namespace ChitCore.Data.v1
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
