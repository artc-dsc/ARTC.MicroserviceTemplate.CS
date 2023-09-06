using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ARTC.Microservice.EntityFrameworkCore;

[ConnectionStringName(MicroserviceDbProperties.ConnectionStringName)]
public interface IMicroserviceDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
