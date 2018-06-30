using ChitFundMgmtApi.ChitMgmt.Post.v1.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChitFundMgmtApi.Data
{
    public class ChitDbContext : DbContext
    {
        #region Constructors
        public ChitDbContext(DbContextOptions<ChitDbContext> options) : base(options)
        { }
        #endregion Constructors

        #region Properties
        public DbSet<Chit> Chits { get; set; }
        #endregion Properties

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        #endregion Methods
    }
}
