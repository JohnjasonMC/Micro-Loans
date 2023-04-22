using LmsAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LmsAPI.Data
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //dipende kung susundan sa docker 
        {
            var server = "(localdb)\\MSSQLLocalDB";
            var db = "LMSDB";

            string connectionString;
            if (_env.IsDevelopment())
            {
                connectionString = $"Server={server};Database={db};MultipleActiveResultSets=true;Integrated Security=false;TrustServerCertificate=true;";
            }
            else
            {
                var userName = "SA";
                var password = "P@ssword123";
                connectionString = $"Server={server};Database={db};User Id= {userName};Password={password};MultipleActiveResultSets=true;Integrated Security=false;TrustServerCertificate=true;";
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
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<GadgetLoan> gadgetloans { get; set; }
    }
}
