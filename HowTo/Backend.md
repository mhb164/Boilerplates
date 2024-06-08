# General How-To 

# ObjectPool 
* [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/performance/objectpool)

# Dependency Injection + ServiceCollection 
* [Using Dependency Injection in .NET Console Apps](https://www.c-sharpcorner.com/article/using-dependency-injection-in-net-console-apps/)
<ul>
    <details>
    <summary>Code</summary>
    ```c#
    using System;
    using Microsoft.Extensions.DependencyInjection
    using Microsoft.Extensions.Logging;

    namespace MyApp
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var services = CreateServices();

                Application app = services.GetRequiredService<Application>();
                app.MyLogic();
            }

            private static ServiceProvider CreateServices()
            {
                var serviceProvider = new ServiceCollection()
                    .AddLogging(options =>
                    {
                        options.ClearProviders();
                        options.AddConsole();
                    })
                    .AddSingleton<Application>(new Application())
                    .BuildServiceProvider();

                return serviceProvider;
            }
        }

        public class Application
        {
            private readonly ILogger<Application> _logger;

            public Application(ILogger<Application> logger)
            {
                _logger = logger;
            }

            public void MyLogic()
            {
                _logger.LogInformation("Hello, World!");
            }
        }
    }
    ```
    </details>
</ul>

* [Use dependency injection in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage)
