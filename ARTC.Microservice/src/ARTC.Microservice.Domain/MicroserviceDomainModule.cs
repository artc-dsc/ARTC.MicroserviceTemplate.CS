using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace ARTC.Microservice;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(MicroserviceDomainSharedModule)
)]
public class MicroserviceDomainModule : AbpModule
{

}
