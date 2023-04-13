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
                new IMP(1, .005, 3),
                new IMP(2, .007, 6),
                new IMP(3, .01, 12),
                new IMP(4, .015, 24));

            modelBuilder.Entity<GadgetLoan>().HasData(
                new GadgetLoan(1, "Iphone 14 ProMax", "The iPhone 14 Pro Max display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 6.69 inches diagonally (actual viewable area is less).", 79999, "https://accenthub.com.ph/wp-content/uploads/2022/10/Apple-iPhone-14-Pro-and-14-Pro-Max-Deep-Purple-1.jpg"),
                new GadgetLoan(2, "Iphone 14 Pro", "The iPhone 14 Pro display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 6.12 inches diagonally (actual viewable area is less).", 75999, "https://accenthub.com.ph/wp-content/uploads/2022/10/Apple-iPhone-14-Pro-and-14-Pro-Max-Deep-Purple-1.jpg"),
                new GadgetLoan(3, "Iphone 13 ProMax", "The iPhone 13 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 6.06 inches diagonally (actual viewable area is less). Both models: HDR display.", 65999, "https://www.apple.com/newsroom/images/product/iphone/standard/Apple_iphone13_hero_09142021_inline.jpg.large.jpg"),
                new GadgetLoan(4, "Iphone 12 ProMax", "The iPhone 12 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 6.06 inches diagonally (actual viewable area is less).", 55999, "https://i0.wp.com/abizot.com.ng/wp-content/uploads/2022/01/Apple-iPhone-12-Blue-64GB.png?fit=940%2C1112&ssl=1"),
                new GadgetLoan(5, "Iphone 11", "The iPhone 11 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 6.06 inches diagonally (actual viewable area is less). Video playback: Up to 17 hours.", 36999, "https://www.techrepublic.com/wp-content/uploads/2019/09/iphone11.jpg"),
                new GadgetLoan(6, "Iphone 11 Pro", "The iPhone 11 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 6.06 inches diagonally (actual viewable area is less). Video playback: Up to 17 hours.", 45999, "https://www.techrepublic.com/wp-content/uploads/2019/09/iphone11.jpg"));
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
                    PhoneNumber = "1234567890",
                    Address ="Somewhere",
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
                    PhoneNumber = "1234567890",
                    Address = "Somewhere",
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
