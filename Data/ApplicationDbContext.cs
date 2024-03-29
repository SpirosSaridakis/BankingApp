﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Padanian_Bank.Models;
using Microsoft.AspNetCore.Identity;

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


    }
}

