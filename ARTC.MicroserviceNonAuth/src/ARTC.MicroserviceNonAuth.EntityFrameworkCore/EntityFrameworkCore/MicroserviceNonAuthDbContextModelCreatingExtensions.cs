using ARTC.MicroserviceNonAuth.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ARTC.MicroserviceNonAuth.EntityFrameworkCore;

public static class MicroserviceNonAuthDbContextModelCreatingExtensions
{
    public static void ConfigureMicroserviceNonAuth(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Book>(b =>
        {
            //Configure table & schema name
            b.ToTable(MicroserviceNonAuthDbProperties.DbTablePrefix + "MicroserviceNonAuth", MicroserviceNonAuthDbProperties.DbSchema);
            b.ConfigureByConvention();
        });
    }
}
