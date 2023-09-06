using ARTC.MicroserviceNonAuth.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ARTC.MicroserviceNonAuth;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(MicroserviceNonAuthEntityFrameworkCoreTestModule)
    )]
public class MicroserviceNonAuthDomainTestModule : AbpModule
{

}
