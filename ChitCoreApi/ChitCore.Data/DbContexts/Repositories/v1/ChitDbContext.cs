using ChitCore.Data.v1.Models;
using Microsoft.EntityFrameworkCore;

namespace ChitCore.Data.v1
{
    public class ChitDbContext : DbContext
    {
        #region Constructors

        public ChitDbContext(DbContextOptions<ChitDbContext> options) : base(options) { }

        #endregion Constructors

        #region Properties

        public DbSet<Chit> Chits { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ChitUser> ChitUsers { get; set; }

        public DbSet<AuctionDetail> AuctionDetails { get; set; }

        public DbSet<PaymentDetail> PaymentDetails { get; set; }

        #endregion Properties

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChitUser>()
                .HasKey(cu => new { cu.ChitId, cu.UserId });

            modelBuilder.Entity<ChitUser>()
                .HasOne(cu => cu.Chit)
                .WithMany(c => c.ChitUsers)
                .HasForeignKey(cu => cu.ChitId);

            modelBuilder.Entity<ChitUser>()
                .HasOne(cu => cu.User)
                .WithMany(u => u.ChitUsers)
                .HasForeignKey(cu => cu.UserId);

            modelBuilder.Entity<ChitAdministrator>()
                .HasKey(cu => new { cu.ChitId, cu.UserId });

            modelBuilder.Entity<ChitAdministrator>()
                .HasOne(ca => ca.Manager)
                .WithMany(ca => ca.ChitAdmins)
                .HasForeignKey(cu => cu.UserId);

            modelBuilder.Entity<ChitAdministrator>()
                .HasOne(ca => ca.Chit)
                .WithOne(ca => ca.Manager);
        }

        #endregion Methods
    }
}
