using LoanManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Data
{
    public static class OMCreating
    {
        public static void OnModelCreating(this ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
            
            modelBuilder.Entity<UGadgetLoan>()
                .HasOne(au => au.ApplicationUser)
                .WithOne(ugl => ugl.UGadgetLoan)
                .HasForeignKey<UGadgetLoan>(au => au.ApplicationUserId);

            modelBuilder.Entity<PLRepayment>()
                .HasOne(au => au.ApplicationUser)
                .WithOne(plr =>plr.PLRepayment)
                .HasForeignKey<PLRepayment>(au => au.ApplicationUserId);

            modelBuilder.Entity<UGadgetLoan>()
               .HasOne(gl => gl.GadgetLoan)
               .WithOne(ugl => ugl.UGadgetLoan)
               .HasForeignKey<UGadgetLoan>(ugl => ugl.GadgetLoanId);

            modelBuilder.Entity<UGadgetLoan>()
               .HasOne(imp => imp.IMP)
               .WithOne(ugl => ugl.UGadgetLoan)
               .HasForeignKey<UGadgetLoan>(ugl => ugl.IMPId);

            modelBuilder.Entity<GLRepayment>()
               .HasOne(ugl => ugl.UGadgetLoan)
               .WithOne(glr => glr.GLRepayment)
               .HasForeignKey<UGadgetLoan>(glr => glr.Id);
            */
            
        }
    }
}

