using LmsAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LmsAPI.Data
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //dipende kung susundan sa docker 
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB; Database=LMSDB; Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<GadgetLoan> gadgetloans { get; set; }
    }
}
