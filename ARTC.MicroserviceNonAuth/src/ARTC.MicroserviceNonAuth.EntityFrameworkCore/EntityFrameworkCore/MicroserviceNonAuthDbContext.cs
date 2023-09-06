using ARTC.MicroserviceNonAuth.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ARTC.MicroserviceNonAuth.EntityFrameworkCore;

[ConnectionStringName(MicroserviceNonAuthDbProperties.ConnectionStringName)]
public class MicroserviceNonAuthDbContext : AbpDbContext<MicroserviceNonAuthDbContext>, IMicroserviceNonAuthDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */
    public DbSet<Book> Books { get; set; }

    public MicroserviceNonAuthDbContext(DbContextOptions<MicroserviceNonAuthDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureMicroserviceNonAuth();
    }
}
