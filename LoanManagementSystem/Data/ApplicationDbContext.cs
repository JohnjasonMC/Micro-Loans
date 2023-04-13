using LoanManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private ILogger _logger { get; }
        private IConfiguration _appConfig { get; }

        public ApplicationDbContext(ILogger<ApplicationDbContext> logger, IConfiguration appConfig)
        {
            this._logger = logger;
            this._appConfig = appConfig;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB; Database=LMSDB; Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedDefaultData();
            modelBuilder.InvokeIdentityRoleSeed();
            modelBuilder.InvokeUsersSeed();
            modelBuilder.InvokeIdentityUserRoleSeed();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });

            modelBuilder.Entity<UGadgetLoan>()
                .HasOne(au => au.ApplicationUser)
                .WithOne(ugl => ugl.UGadgetLoan)
                .HasForeignKey<UGadgetLoan>(au => au.ApplicationUserId);

            modelBuilder.Entity<UGadgetLoan>()
                .HasOne(gl => gl.GadgetLoan)
                .WithOne(ugl => ugl.UGadgetLoan)
                .HasForeignKey<UGadgetLoan>(ugl => ugl.GadgetLoanId);

            modelBuilder.Entity<UGadgetLoan>()
                .HasOne(imp => imp.IMP)
                .WithOne(ugl => ugl.UGadgetLoan)
                .HasForeignKey<UGadgetLoan>(ugl => ugl.IMPId);

            modelBuilder.Entity<Purchase>()
                .Property(p => p.Interest)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Purchase>()
                .Property(p => p.Payment)
                .HasColumnType("decimal(18, 2)");
        }
        public DbSet<IMP> imps{ get; set; }
        public DbSet<GadgetLoan> gadgetloans { get; set; }
        public DbSet<UGadgetLoan> ugadgetloans { get; set; }
        public DbSet<Purchase> purchases { get; set; }
    }
}
