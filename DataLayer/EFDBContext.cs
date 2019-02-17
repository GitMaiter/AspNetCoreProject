using DataLayer.Enityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class EFDBContext : DbContext
    {
        public DbSet<Directory> Directory { get; set; }
        public DbSet<Material> Material { get; set; }
        public EFDBContext(DbContextOptions<EFDBContext> options) : base (options) { }
    }


    // For Migrations
    public class DbContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AspNetCoreProj;Trusted_Connection=True;MultipleActiveResultSets=True", b => b.MigrationsAssembly("DataLayer"));
            return new EFDBContext(optionsBuilder.Options);
        }
    }

}
