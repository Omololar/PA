using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Data;

namespace Web.Extension
{
    public static class DatabaseExtensions
    {
        public static void MigrateDb(this IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AgroEntities>();
                context.Database.Migrate();
            }
        }
    }
}
