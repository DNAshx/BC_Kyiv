using Microsoft.EntityFrameworkCore;
using System;

namespace BCKyivApp_Data
{
    public class StorageContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=storage.db");
        }
    }
}
