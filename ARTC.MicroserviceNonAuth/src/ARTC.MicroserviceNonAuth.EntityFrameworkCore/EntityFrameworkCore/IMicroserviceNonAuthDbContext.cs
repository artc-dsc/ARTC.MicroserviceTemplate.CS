using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ARTC.MicroserviceNonAuth.EntityFrameworkCore;

[ConnectionStringName(MicroserviceNonAuthDbProperties.ConnectionStringName)]
public interface IMicroserviceNonAuthDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
