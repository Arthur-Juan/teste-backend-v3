using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using TheatricalPlayersRefactoringKata.Application.Services;
using TheatricalPlayersRefactoringKata.Data;
using TheatricalPlayersRefactoringKata.Data.Extensions;

namespace TheatricalPlayersRefactoringKata.Tests
{
    public class TestServiceProvider
    {
        public static IServiceProvider CreateServiceProvider()
        {
            // Set DataDirectory
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var _configuration = builder.Build();

            // Configure the service collection
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();
            serviceCollection.ConfigureData(_configuration);
            serviceCollection.AddScoped<CustomerService>();
            var _serviceProvider = serviceCollection.BuildServiceProvider();

            // Ensure database schema creation
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated(); // This should create the database file
            }

            return _serviceProvider;
        }
    }
}