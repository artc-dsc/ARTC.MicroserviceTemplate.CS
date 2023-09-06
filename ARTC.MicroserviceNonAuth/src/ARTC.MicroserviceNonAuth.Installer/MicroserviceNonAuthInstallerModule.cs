using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ARTC.MicroserviceNonAuth;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class MicroserviceNonAuthInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<MicroserviceNonAuthInstallerModule>();
        });
    }
}
