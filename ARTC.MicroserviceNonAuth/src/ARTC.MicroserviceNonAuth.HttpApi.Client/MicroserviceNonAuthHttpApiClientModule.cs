using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ARTC.MicroserviceNonAuth;

[DependsOn(
    typeof(MicroserviceNonAuthApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class MicroserviceNonAuthHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(MicroserviceNonAuthApplicationContractsModule).Assembly,
            MicroserviceNonAuthRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<MicroserviceNonAuthHttpApiClientModule>();
        });

    }
}
