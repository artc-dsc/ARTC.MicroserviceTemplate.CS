using Localization.Resources.AbpUi;
using ARTC.MicroserviceNonAuth.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace ARTC.MicroserviceNonAuth;

[DependsOn(
    typeof(MicroserviceNonAuthApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class MicroserviceNonAuthHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(MicroserviceNonAuthHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<MicroserviceNonAuthResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
