using System.Reflection;
using DataAccesLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DBContext;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext() 
    {
        
    }

    public DbContext(DbContextOptions<DbContext> options) : base(options)
    {

    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        if (!optionsBuilder.IsConfigured)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(config.GetSection("ConnectionStrings").GetValue<string>("AssetsDb"));
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
        }
    }
    
    public virtual DbSet<Assets> Assets { get; set; }
    public virtual DbSet<DeviceGroup> DeviceGroup { get; set; }
}