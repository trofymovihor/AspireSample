using Microsoft.EntityFrameworkCore;

namespace AspireSample.ApiService.Data;

public class DbInitializer : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<DbInitializer> _logger;

    public DbInitializer(
        IServiceProvider serviceProvider,
        ILogger<DbInitializer> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        try
        {
            _logger.LogInformation("Attempting to apply migrations...");
            await dbContext.Database.MigrateAsync(cancellationToken);

            if (!await dbContext.Users.AnyAsync(cancellationToken))
            {
                _logger.LogInformation("Seeding users...");

                var users = new List<User>
                {
                    new User 
                    { 
                        Name = "John Doe",
                        Email = "john.doe@example.com",
                        CreatedAt = DateTime.UtcNow
                    },
                    new User 
                    { 
                        Name = "Jane Smith",
                        Email = "jane.smith@example.com",
                        CreatedAt = DateTime.UtcNow
                    },
                    new User 
                    { 
                        Name = "Bob Johnson",
                        Email = "bob.johnson@example.com",
                        CreatedAt = DateTime.UtcNow
                    }
                };

                await dbContext.Users.AddRangeAsync(users, cancellationToken);
                await dbContext.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("User seed data applied successfully.");
            }

            if (!await dbContext.Products.AnyAsync(cancellationToken))
            {
                _logger.LogInformation("Seeding products...");

                var products = new List<Product>
                {
                    new Product 
                    { 
                        Name = "Coffee Maker",
                        Price = 89.99m,
                        StockQuantity = 50,
                        Description = "Premium coffee maker with timer"
                    },
                    new Product 
                    { 
                        Name = "Gaming Mouse",
                        Price = 59.99m,
                        StockQuantity = 100,
                        Description = "High precision gaming mouse"
                    },
                    new Product 
                    { 
                        Name = "Wireless Keyboard",
                        Price = 79.99m,
                        StockQuantity = 75,
                        Description = "Ergonomic wireless keyboard"
                    }
                };

                await dbContext.Products.AddRangeAsync(products, cancellationToken);
                await dbContext.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("Product seed data applied successfully.");
            }
            else
            {
                _logger.LogInformation("Database already contains data - skipping seed.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing the database.");
            throw;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}