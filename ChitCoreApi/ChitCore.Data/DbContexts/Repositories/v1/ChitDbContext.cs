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

        public virtual DbSet<AuctionDetail> AuctionDetails { get; set; }
        public virtual DbSet<ChitAdministrator> ChitAdministrator { get; set; }
        public virtual DbSet<Chit> Chits { get; set; }
        public virtual DbSet<ChitUser> ChitUsers { get; set; }
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }

        #endregion Properties

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuctionDetail>(entity =>
            {
                entity.HasOne(d => d.Chit)
                    .WithMany(p => p.AuctionDetails)
                    .HasForeignKey(d => d.ChitId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuctionDetails)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<ChitAdministrator>(entity =>
            {
                entity.HasIndex(e => e.ChitId)
                    .IsUnique();

                entity.HasIndex(e => e.Id)
                    .HasName("AK_ChitAdministrator_Id")
                    .IsUnique();

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Chit)
                    .WithOne(p => p.ChitAdministrator)
                    .HasForeignKey<ChitAdministrator>(d => d.ChitId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ChitAdministrator)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Chit>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<ChitUser>(entity =>
            {
                entity.HasKey(e => new { e.ChitId, e.UserId });

                entity.HasIndex(e => e.Id)
                    .HasName("AK_ChitUsers_Id")
                    .IsUnique();

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Chit)
                    .WithMany(p => p.ChitUsers)
                    .HasForeignKey(d => d.ChitId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ChitUsers)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<PaymentDetail>(entity =>
            {
                entity.HasOne(d => d.Chit)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.ChitId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.Minitial).HasColumnName("MInitial");

                entity.Property(e => e.PhoneNumber).IsRequired();
            });
        }

        #endregion Methods
    }
}
