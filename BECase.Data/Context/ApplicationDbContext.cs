﻿using BECase.Common.Entities.Common;
using BECase.Data.Mapping;
using BECase.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BECase.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            //Database.Migrate();
        }


        //public DbSet<AppUser> AppUsers { get; set; }
        //public DbSet<JwtRefreshToken> JwtRefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null) throw new ArgumentNullException(nameof(modelBuilder));

            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName != null && tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName($"{RepositoryDefaults.identityTablesPrefix}" + tableName.Substring(6));
                }
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new InvoiceLineMap());
            modelBuilder.ApplyConfiguration(new InvoiceMap());
            modelBuilder.ApplyConfiguration(new JwtRefreshTokenMap());
        }
    }
}
