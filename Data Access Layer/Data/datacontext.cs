using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
namespace Data_Access_Layer.Data
{ 
  public class datacontext :IdentityDbContext<user>
     
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               
                optionsBuilder.UseSqlServer("Server=.;Database=Bankingdb;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<user>().Property(u=> u.Pin).HasMaxLength(5).IsRequired();
            builder.Entity<Account>().HasOne(a => a.user).WithMany(u => u.Accounts).HasForeignKey(u => u.UserId);
            builder.Entity<Loan>().HasOne(a => a.account).WithMany(u =>u.loans).HasForeignKey(u => u.AccountId).OnDelete(DeleteBehavior.ClientCascade);
           // builder.Entity<Transfer>().HasOne(a => a.user).WithMany(u => u.transfers).HasForeignKey(u => u.UserId);
            builder.Entity<Transfer>().HasOne(a => a.FromAccount).WithMany(a => a.FromTransfers).HasForeignKey(a => a.FromAccountId).OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<withdraw>().HasOne(u => u.Account).WithMany(a => a.withdraws).HasForeignKey(a => a.AccountId).OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<Transfer>().HasOne(a => a.ToAccount).WithMany(a => a.ToTransfers).HasForeignKey(a => a.ToAccountId).OnDelete(DeleteBehavior.ClientCascade);
        }
        public  DbSet<user> users { get; set; }
        public  DbSet<Account> accounts { get; set; }
        public DbSet<Loan> loans { get; set; }
        public DbSet<Transfer> transfer { get; set; }
        public DbSet<withdraw> withdraws { get; set; }

    }
}
