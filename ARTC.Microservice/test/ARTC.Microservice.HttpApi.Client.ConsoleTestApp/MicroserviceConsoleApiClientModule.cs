using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace ARTC.Microservice;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MicroserviceHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class MicroserviceConsoleApiClientModule : AbpModule
{

}
