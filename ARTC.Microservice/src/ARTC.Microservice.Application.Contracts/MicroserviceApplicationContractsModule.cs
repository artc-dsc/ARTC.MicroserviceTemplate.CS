using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace ARTC.Microservice;

[DependsOn(
    typeof(MicroserviceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class MicroserviceApplicationContractsModule : AbpModule
{

}
