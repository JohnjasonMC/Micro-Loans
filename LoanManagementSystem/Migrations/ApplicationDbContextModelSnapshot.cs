﻿// <auto-generated />
using System;
using LoanManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LoanManagementSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LoanManagementSystem.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "147c0de8-847c-4466-ad04-1fc7b563e0c4",
                            AccessFailedCount = 0,
                            Address = "Somewhere",
                            ConcurrencyStamp = "eae85b33-bd54-4dc3-a20d-8cbbe74423f9",
                            DateOfBirth = new DateTime(2023, 4, 18, 0, 58, 10, 723, DateTimeKind.Local).AddTicks(1754),
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FullName = "Admin",
                            Gender = " ",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEESsHVGSeVdRea4wSFrU8EmO/E/anj3AkaysiLBJnXXnhalFSRmPxCh40snXfG2AAA==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "88bdba3a-87f9-47be-830f-7780616ae99e",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = "cba87ff8-bb15-442f-8a47-0e65a93cab8c",
                            AccessFailedCount = 0,
                            Address = "Somewhere",
                            ConcurrencyStamp = "9d94db0e-84fa-408b-b516-9412b5f9f073",
                            DateOfBirth = new DateTime(2023, 4, 18, 0, 58, 10, 724, DateTimeKind.Local).AddTicks(6750),
                            Email = "registered@gmail.com",
                            EmailConfirmed = false,
                            FullName = "Registered",
                            Gender = "M",
                            LockoutEnabled = false,
                            NormalizedEmail = "REGISTERED@GMAIL.COM",
                            NormalizedUserName = "REGISTERED@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEMak7j4q/UAdbBGUlmvUXkNjdngsLvHDKL9Zyszkks+6udpV9Lg06t9Cjv7bqk9QmQ==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "866dec3f-45cb-472b-af46-14c9452bbbee",
                            TwoFactorEnabled = false,
                            UserName = "registered@gmail.com"
                        });
                });

            modelBuilder.Entity("LoanManagementSystem.Models.GadgetLoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GadgetImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GadgetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("gadgetloans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The iPhone 14 Pro Max display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 6.69 inches diagonally (actual viewable area is less).",
                            GadgetImageURL = "https://accenthub.com.ph/wp-content/uploads/2022/10/Apple-iPhone-14-Pro-and-14-Pro-Max-Deep-Purple-1.jpg",
                            GadgetName = "Iphone 14 ProMax",
                            Price = 79999
                        },
                        new
                        {
                            Id = 2,
                            Description = "The iPhone 14 Pro display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 6.12 inches diagonally (actual viewable area is less).",
                            GadgetImageURL = "https://accenthub.com.ph/wp-content/uploads/2022/10/Apple-iPhone-14-Pro-and-14-Pro-Max-Deep-Purple-1.jpg",
                            GadgetName = "Iphone 14 Pro",
                            Price = 75999
                        },
                        new
                        {
                            Id = 3,
                            Description = "The iPhone 13 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 6.06 inches diagonally (actual viewable area is less). Both models: HDR display.",
                            GadgetImageURL = "https://www.apple.com/newsroom/images/product/iphone/standard/Apple_iphone13_hero_09142021_inline.jpg.large.jpg",
                            GadgetName = "Iphone 13 ProMax",
                            Price = 65999
                        },
                        new
                        {
                            Id = 4,
                            Description = "The iPhone 12 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 6.06 inches diagonally (actual viewable area is less).",
                            GadgetImageURL = "https://i0.wp.com/abizot.com.ng/wp-content/uploads/2022/01/Apple-iPhone-12-Blue-64GB.png?fit=940%2C1112&ssl=1",
                            GadgetName = "Iphone 12 ProMax",
                            Price = 55999
                        },
                        new
                        {
                            Id = 5,
                            Description = "The iPhone 11 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 6.06 inches diagonally (actual viewable area is less). Video playback: Up to 17 hours.",
                            GadgetImageURL = "https://www.techrepublic.com/wp-content/uploads/2019/09/iphone11.jpg",
                            GadgetName = "Iphone 11",
                            Price = 36999
                        },
                        new
                        {
                            Id = 6,
                            Description = "The iPhone 11 display has rounded corners that follow a beautiful curved design, and these corners are within a standard rectangle. When measured as a standard rectangular shape, the screen is 6.06 inches diagonally (actual viewable area is less). Video playback: Up to 17 hours.",
                            GadgetImageURL = "https://www.techrepublic.com/wp-content/uploads/2019/09/iphone11.jpg",
                            GadgetName = "Iphone 11 Pro",
                            Price = 45999
                        });
                });

            modelBuilder.Entity("LoanManagementSystem.Models.IMP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Interest")
                        .HasColumnType("float");

                    b.Property<int>("PaymentTerm")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("imps");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Interest = 0.5,
                            PaymentTerm = 3
                        },
                        new
                        {
                            Id = 2,
                            Interest = 0.69999999999999996,
                            PaymentTerm = 6
                        },
                        new
                        {
                            Id = 3,
                            Interest = 1.0,
                            PaymentTerm = 12
                        },
                        new
                        {
                            Id = 4,
                            Interest = 1.5,
                            PaymentTerm = 24
                        });
                });

            modelBuilder.Entity("LoanManagementSystem.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DatePurchased")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GadgetImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GadgetLoanId")
                        .HasColumnType("int");

                    b.Property<string>("GadgetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Interest")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Payment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PaymentTerm")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("GadgetLoanId");

                    b.ToTable("purchases");
                });

            modelBuilder.Entity("LoanManagementSystem.Models.UGadgetLoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double?>("AnnualRate")
                        .HasColumnType("float");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("GadgetLoanId")
                        .HasColumnType("int");

                    b.Property<int>("IMPId")
                        .HasColumnType("int");

                    b.Property<double>("Payment")
                        .HasColumnType("float");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique();

                    b.HasIndex("GadgetLoanId")
                        .IsUnique();

                    b.HasIndex("IMPId")
                        .IsUnique();

                    b.ToTable("ugadgetloans");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "705c9705-c8a8-44af-99a3-e33b13856856",
                            ConcurrencyStamp = "d8bc9208-2d97-4498-901e-726fe349c3cd",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "1a73053f-78c6-41c2-94fc-d897ccc8b33c",
                            ConcurrencyStamp = "557787e4-2cb6-423c-965f-2efa9478cd2f",
                            Name = "Registered",
                            NormalizedName = "REGISTERED"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "147c0de8-847c-4466-ad04-1fc7b563e0c4",
                            RoleId = "705c9705-c8a8-44af-99a3-e33b13856856"
                        },
                        new
                        {
                            UserId = "cba87ff8-bb15-442f-8a47-0e65a93cab8c",
                            RoleId = "1a73053f-78c6-41c2-94fc-d897ccc8b33c"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("LoanManagementSystem.Models.Purchase", b =>
                {
                    b.HasOne("LoanManagementSystem.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoanManagementSystem.Models.GadgetLoan", "GadgetLoan")
                        .WithMany()
                        .HasForeignKey("GadgetLoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("GadgetLoan");
                });

            modelBuilder.Entity("LoanManagementSystem.Models.UGadgetLoan", b =>
                {
                    b.HasOne("LoanManagementSystem.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("UGadgetLoan")
                        .HasForeignKey("LoanManagementSystem.Models.UGadgetLoan", "ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoanManagementSystem.Models.GadgetLoan", "GadgetLoan")
                        .WithOne("UGadgetLoan")
                        .HasForeignKey("LoanManagementSystem.Models.UGadgetLoan", "GadgetLoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoanManagementSystem.Models.IMP", "IMP")
                        .WithOne("UGadgetLoan")
                        .HasForeignKey("LoanManagementSystem.Models.UGadgetLoan", "IMPId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("GadgetLoan");

                    b.Navigation("IMP");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LoanManagementSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LoanManagementSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoanManagementSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("LoanManagementSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LoanManagementSystem.Models.ApplicationUser", b =>
                {
                    b.Navigation("UGadgetLoan")
                        .IsRequired();
                });

            modelBuilder.Entity("LoanManagementSystem.Models.GadgetLoan", b =>
                {
                    b.Navigation("UGadgetLoan")
                        .IsRequired();
                });

            modelBuilder.Entity("LoanManagementSystem.Models.IMP", b =>
                {
                    b.Navigation("UGadgetLoan")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
