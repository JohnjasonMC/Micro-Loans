using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace LoanManagementSystem.Data
{
    public static class AutoMigrations
    {
        public static void AutoMigrate(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using(var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch(Exception ex)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
