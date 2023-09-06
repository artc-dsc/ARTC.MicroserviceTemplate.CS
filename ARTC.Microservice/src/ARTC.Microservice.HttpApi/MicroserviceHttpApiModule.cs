using Localization.Resources.AbpUi;
using ARTC.Microservice.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace ARTC.Microservice;

[DependsOn(
    typeof(MicroserviceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class MicroserviceHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(MicroserviceHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<MicroserviceResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
