using Volo.Abp.Modularity;

namespace ARTC.MicroserviceNonAuth;

[DependsOn(
    typeof(MicroserviceNonAuthApplicationModule),
    typeof(MicroserviceNonAuthDomainTestModule)
    )]
public class MicroserviceNonAuthApplicationTestModule : AbpModule
{

}
