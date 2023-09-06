using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTC.Microservice.EntityFrameworkCore
{
    public class MicroserviceDbContextFactory : IDesignTimeDbContextFactory<MicroserviceDbContext>
    {
        public MicroserviceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MicroserviceDbContext>()
                .UseSqlServer(GetConnectionStringFromConfiguration());
            return new MicroserviceDbContext(builder.Options);
        }

        private static string GetConnectionStringFromConfiguration()
        {
            return BuildConfiguration()
                .GetConnectionString(MicroserviceDbProperties.ConnectionStringName);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(
                    Path.Combine(
                        Directory.GetCurrentDirectory(),
                        $"..{Path.DirectorySeparatorChar}ARTC.Microservice.HttpApi.Host"
                    )
                )
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
