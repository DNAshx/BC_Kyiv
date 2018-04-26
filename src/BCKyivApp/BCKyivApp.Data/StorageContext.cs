using BCKyivApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BCKyivApp.Data
{
    public class StorageContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Centre> Centres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=storage.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* 
             * We can't use alternative keys from EF because of exception on update
             * workaround for implement alternative keys is to using Unique index
             * source: http://stackoverflow.com/questions/35309553/the-property-on-entity-type-is-part-of-a-key-and-so-cannot-be-modified-or-marked
             */

            modelBuilder.Entity<Contact>().HasAlternateKey(f => f.CentreId);

            modelBuilder.Entity<Contact>()
                .HasOne(co => co.Centre)
                .WithMany(ce => ce.Contacts)
                .HasForeignKey(co => co.CentreId);
        }
    }
}
