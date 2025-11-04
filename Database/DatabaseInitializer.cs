

public class DatabaseInitializer
{
    private readonly ILogger<DatabaseInitializer> _logger;

    public DatabaseInitializer(ILogger<DatabaseInitializer> logger)
    {
        _logger = logger;
    }

    public async Task EnsureDatabaseExists()
    {
        try
        {
            // Here you would typically:
            // 1. Check if database exists
            // 2. Create if it doesn't exist
            _logger.LogInformation("Ensuring database exists...");
            await Task.Delay(100); // Simulate work
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error ensuring database exists");
            throw;
        }
    }

    public async Task InitializeDatabase()
    {
        try
        {
            // Here you would typically:
            // 1. Create tables
            // 2. Add indexes
            // 3. Set up constraints
            _logger.LogInformation("Initializing database structure...");
            await Task.Delay(100); // Simulate work
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error initializing database");
            throw;
        }
    }

    public async Task SeedInitialData()
    {
        try
        {
            // Here you would typically:
            // 1. Check if data exists
            // 2. Insert initial data if needed
            var sampleProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Sample Product 1", Price = 19.99m },
                new Product { Id = 1, Name = "Sample Product 3", Price = 39.99m },
                new Product { Id = 1, Name = "Sample Product 4", Price = 49.99m },
                new Product { Id = 1, Name = "Sample Product 5", Price = 59.99m },
                new Product { Id = 2, Name = "Sample Product 2", Price = 29.99m }
            };

            _logger.LogInformation("Seeding initial data...");
            await Task.Delay(100); // Simulate work
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error seeding initial data");
            throw;
        }
    }
}
