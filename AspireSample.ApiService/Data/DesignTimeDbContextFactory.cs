using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AspireSample.ApiService.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        // Using the same database name as configured in AppHost.cs
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=EffortlessDb;Username=postgres;Password=postgres;Include Error Detail=true");

        return new AppDbContext(optionsBuilder.Options);
    }
}