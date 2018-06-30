using ChitFundMgmtApi.ChitMgmt.Repository;
using ChitFundMgmtApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ChitFundMgmtApi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Members
        private ChitDbContext dbContext;
        #endregion Members

        #region Constructors
        public UnitOfWork(ChitDbContext _dbContext)
        {
            dbContext = _dbContext;
            Chits = new ChitRepository(_dbContext);
        }
        #endregion Constructors

        #region Properties
        public IChitRepository Chits { get; set; }
        #endregion Properties

        #region Methods
        public bool Complete()
        {
            try
            {
                return dbContext.SaveChanges() >= 0;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException.GetType().Name.Equals("SqlException"))
                    return false;
                else
                    throw ex;
            }
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
        #endregion Methods
    }
}
