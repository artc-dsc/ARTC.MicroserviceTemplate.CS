using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ARTC.MicroserviceNonAuth.EntityFrameworkCore
{
    public class MicroserviceNonAuthDbContextFactory : IDesignTimeDbContextFactory<MicroserviceNonAuthDbContext>
    {
        public MicroserviceNonAuthDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MicroserviceNonAuthDbContext>()
                .UseSqlServer(GetConnectionStringFromConfiguration());
            return new MicroserviceNonAuthDbContext(builder.Options);
        }

        private static string GetConnectionStringFromConfiguration()
        {
            return BuildConfiguration()
                .GetConnectionString(MicroserviceNonAuthDbProperties.ConnectionStringName);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(
                    Path.Combine(
                        Directory.GetCurrentDirectory(),
                        $"..{Path.DirectorySeparatorChar}ARTC.MicroserviceNonAuth.HttpApi.Host"
                    )
                )
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}