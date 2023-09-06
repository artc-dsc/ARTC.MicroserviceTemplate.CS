using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace ARTC.MicroserviceNonAuth;

[DependsOn(
    typeof(MicroserviceNonAuthDomainModule),
    typeof(MicroserviceNonAuthApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class MicroserviceNonAuthApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<MicroserviceNonAuthApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<MicroserviceNonAuthApplicationModule>(validate: true);
        });
    }
}
