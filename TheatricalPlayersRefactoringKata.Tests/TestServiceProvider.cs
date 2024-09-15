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
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var _configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();
            serviceCollection.ConfigureData(_configuration);

            serviceCollection.AddScoped<CustomerService>();
            serviceCollection.AddScoped<PlaysService>();

            var _serviceProvider = serviceCollection.BuildServiceProvider();

            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated(); 

            }

            return _serviceProvider;
        }
    }
}