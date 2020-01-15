﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SumerBusinessSolution.Models;

namespace SumerBusinessSolution.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<InvStockQty> InvStockQty { get; set; }
        public DbSet<InvTransaction> InvTransaction { get; set; }
        public DbSet<InvTransfer> InvTransfer { get; set; }
        public DbSet<ProdInfo> ProdInfo { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<WhType> WhType { get; set; }
        public DbSet<IncomingGood> IncomingGood { get; set; }
        public DbSet<TempProdImg> TempProdImg { get; set; }
        public DbSet<ProdImg> ProdImg { get; set; }
    }
}