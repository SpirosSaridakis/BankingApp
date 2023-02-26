using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Padanian_Bank.Models;

namespace Padanian_Bank.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Padanian_Bank.Models.Account> Account { get; set; }
        public DbSet<Padanian_Bank.Models.Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the primary key for the MyTable table
            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.Account_id);

        }

    }
}

