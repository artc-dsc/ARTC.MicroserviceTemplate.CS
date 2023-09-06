using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace ARTC.MicroserviceNonAuth;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(MicroserviceNonAuthDomainSharedModule)
)]
public class MicroserviceNonAuthDomainModule : AbpModule
{

}
