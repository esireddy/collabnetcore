using ChitCore.Data.v1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public new Chit Get(int id)
        {
            var result = ChitDbContext.Chits.
                Include(x => x.ChitAdministrator)
                .ThenInclude(y => y.User)
                .Where(x => x.Id == id).First();
            return result;
        }

        #endregion Properties
    }
}
