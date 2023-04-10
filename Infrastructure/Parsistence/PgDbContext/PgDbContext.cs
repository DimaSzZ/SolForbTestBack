using System.Reflection;
using Domain.Models.Order;
using Domain.Models.OrderItem;
using Domain.Models.Provider;
using Infrastructure.Parsistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Parsistence.PgDbContext;

public class PgDbContext : DbContext
{
    public PgDbContext() : base()
    {
        
    }
    public PgDbContext(DbContextOptions<PgDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "../SolForbTestBack.Api/appsettings.json"))
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(),
                    $"../Api/appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json"),
                optional: true)
            .Build();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Provider> Providers { get; set; }
}