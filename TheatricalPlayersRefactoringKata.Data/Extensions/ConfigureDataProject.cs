using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata.Data.Extensions
{
    public static class ConfigureDataProject
    {

        public static void ConfigureData(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlite(configuration.GetConnectionString("SqliteConnection"));

            });
        }
    }
}
