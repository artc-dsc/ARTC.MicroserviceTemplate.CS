using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using ARTC.MicroserviceNonAuth.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace ARTC.MicroserviceNonAuth;

[DependsOn(
    typeof(AbpValidationModule)
)]
public class MicroserviceNonAuthDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<MicroserviceNonAuthDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<MicroserviceNonAuthResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/MicroserviceNonAuth");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("MicroserviceNonAuth", typeof(MicroserviceNonAuthResource));
        });
    }
}
