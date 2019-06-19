using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataLayer
{
    public class EFDBContext : DbContext
    {
        public DbSet<CoffeeDbModel> CoffeeDbModel { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base (options) { }
    }

    // For Migrations
    public class DbContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseSqlServer("Server=localhost,11433; database=CoffeeMakerDB;user id=sa;password=Pwd12345!", b => b.MigrationsAssembly("DataLayer"));
            return new EFDBContext(optionsBuilder.Options);
        }
    }

}
