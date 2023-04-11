using LoanManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Data
{
    public static class Seed
    {
        public static void SeedDefaultData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IMP>().HasData(
                new IMP(1, .8, 3),
                new IMP(2, 01.00, 6),
                new IMP(3, 06.00, 12),
                new IMP(4, 06.00, 24));
        }
        public static void InvokeIdentityRoleSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "705c9705-c8a8-44af-99a3-e33b13856856",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id = "1a73053f-78c6-41c2-94fc-d897ccc8b33c",
                    Name = "Registered",
                    NormalizedName = "REGISTERED"
                }
            );
        }
        public static void InvokeUsersSeed(this ModelBuilder modelBuilder)
        {
            string defaultPassword = "P@ssword123";

            var passwordHasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "147c0de8-847c-4466-ad04-1fc7b563e0c4",
                    FullName = "Admin",
                    DateOfBirth = DateTime.Now,
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    NormalizedUserName = "admin@gmail.com".ToUpper(),
                    NormalizedEmail = "admin@gmail.com".ToUpper(),
                    PasswordHash = passwordHasher.HashPassword(null, defaultPassword)
                },
                new ApplicationUser
                {
                    Id = "cba87ff8-bb15-442f-8a47-0e65a93cab8c",
                    FullName = "Registered",
                    DateOfBirth = DateTime.Now,
                    Gender = 'M',
                    UserName = "registered@gmail.com",
                    Email = "registered@gmail.com",
                    NormalizedUserName = "registered@gmail.com".ToUpper(),
                    NormalizedEmail = "registered@gmail.com".ToUpper(),
                    PasswordHash = passwordHasher.HashPassword(null, defaultPassword)
                }
                );
        }
        public static void InvokeIdentityUserRoleSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "705c9705-c8a8-44af-99a3-e33b13856856",
                    UserId = "147c0de8-847c-4466-ad04-1fc7b563e0c4"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "1a73053f-78c6-41c2-94fc-d897ccc8b33c",
                    UserId = "cba87ff8-bb15-442f-8a47-0e65a93cab8c"
                }
            );
        }
    }
}
