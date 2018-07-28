using ChitCore.Data.v1.Models;

namespace ChitCore.Data.v1
{
    public class ChitAdministratorRepository : Repository<ChitAdministrator>, IChitAdministratorRepository
    {
        #region Constructors

        public ChitAdministratorRepository(ChitDbContext dbContext) : base(dbContext) { }

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
