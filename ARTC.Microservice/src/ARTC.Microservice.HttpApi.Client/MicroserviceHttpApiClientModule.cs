using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ARTC.Microservice;

[DependsOn(
    typeof(MicroserviceApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class MicroserviceHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(MicroserviceApplicationContractsModule).Assembly,
            MicroserviceRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<MicroserviceHttpApiClientModule>();
        });

    }
}
