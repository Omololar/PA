
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.Data;

namespace Web
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AgroEntities>
    {
        public AgroEntities CreateDbContext(string[] args)
        {


            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var builder = new DbContextOptionsBuilder<AgroEntities>();

            builder.UseSqlServer(configuration["ConnectionStrings:DataEntities"], b => b.MigrationsAssembly(typeof(Startup).Assembly.FullName));
            // builder.UseOpenIddict();

            return new AgroEntities(builder.Options);
        }
    }
}
