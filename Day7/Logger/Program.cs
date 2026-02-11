using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        // Setup dependency injection container
        var serviceProvider = new ServiceCollection()
            .AddLogging(builder =>
            {
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Information);
            })
            .AddTransient<UserService>()
            .BuildServiceProvider();

        // Get the UserService from DI container
        var userService = serviceProvider.GetRequiredService<UserService>();

        // Use the service
        userService.CreateUser("John");
        userService.CreateUser("Jane");
    }
}

public class UserService
{
    private readonly ILogger<UserService> _logger;

    public UserService(ILogger<UserService> logger)
    {
        _logger = logger;
    }

    public void CreateUser(string name)
    {     
         // Log : "Creating user: John"
        _logger.LogInformation("Creating user: {Name}", name);

        
        try
        {
            // Create User..
          _logger.LogInformation("User created successfully: {Name}", name);  
        }
        catch (Exception ex)
        {
            // Log error with exception
            _logger.LogError(ex, "Error creating user: {Name}", name);
        }
    }
}

//dotnet add package Microsoft.Extensions.Logging.Abstractions