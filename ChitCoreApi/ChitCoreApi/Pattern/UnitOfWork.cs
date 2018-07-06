using ChitCoreApi.ChitMgmt.Pattern;
using ChitCoreApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ChitCoreApi.Pattern
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

        public IChitRepository Chits { get; set; }

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
    }
}
