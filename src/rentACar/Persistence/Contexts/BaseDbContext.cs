using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext: DbContext
{
    
    public IConfiguration Configuration { get; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Fuel> Fuels { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }
    public DbSet<Model> Models { get; set; }
    
    protected BaseDbContext(IConfiguration configuration, DbSet<Brand> brands)
    {
        Configuration = configuration;
        Brands = brands;
    }

    public BaseDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}