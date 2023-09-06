using Volo.Abp.Modularity;

namespace ARTC.Microservice;

[DependsOn(
    typeof(MicroserviceApplicationModule),
    typeof(MicroserviceDomainTestModule)
    )]
public class MicroserviceApplicationTestModule : AbpModule
{

}
