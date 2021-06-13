using ProjectAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<CountryInfo> CountryInfos { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CountryInfo>().HasKey(ss => ss.City);
            
            modelBuilder.Entity<CountryInfo>().HasKey(ss => ss.Id);
            modelBuilder.Entity<CountryInfo>(entity =>
            {
                entity.Property(e => e.City)
                       .IsRequired()
                       .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Isfavourite)
                .HasDefaultValue(false);

                entity.Property(e => e.Email).IsRequired();

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
