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
        public IWebHostEnvironment _env { get; }

        public ApplicationDbContext(ILogger<ApplicationDbContext> logger, IConfiguration appConfig, IWebHostEnvironment env)
        {
            this._logger = logger;
            this._appConfig = appConfig;
            this._env = env;

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var server = _appConfig.GetConnectionString("Server");
            var db = _appConfig.GetConnectionString("DB");

            string connectionString;
            if (_env.IsDevelopment())
            {
                connectionString = $"Server={server};Database={db};MultipleActiveResultSets=true; Trusted_Connection=true; TrustServerCertificate=true;";
            }
            else
            {
                var userName = _appConfig.GetConnectionString("UserName");
                var password = _appConfig.GetConnectionString("Password");
                connectionString = $"Server={server};Database={db};User Id= {userName};Password={password};MultipleActiveResultSets=true; Trusted_Connection=true; TrustServerCertificate=true;";
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("Connection string is not configured.");
            }

            optionsBuilder.UseSqlServer(connectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            })
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

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
