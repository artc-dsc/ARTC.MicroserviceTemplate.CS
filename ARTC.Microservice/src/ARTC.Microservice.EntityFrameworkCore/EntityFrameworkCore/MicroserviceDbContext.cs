using ARTC.Microservice.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ARTC.Microservice.EntityFrameworkCore;

[ConnectionStringName(MicroserviceDbProperties.ConnectionStringName)]
public class MicroserviceDbContext : AbpDbContext<MicroserviceDbContext>, IMicroserviceDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */
    public DbSet<Book> Books { get; set; }

    public MicroserviceDbContext(DbContextOptions<MicroserviceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureMicroservice();
    }
}
