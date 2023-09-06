using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ARTC.MicroserviceNonAuth.EntityFrameworkCore;

[DependsOn(
    typeof(MicroserviceNonAuthDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class MicroserviceNonAuthEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<MicroserviceNonAuthDbContext>(options =>
        {
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            options.UseSqlServer();
        });
    }
}
