using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace ARTC.MicroserviceNonAuth;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MicroserviceNonAuthHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class MicroserviceNonAuthConsoleApiClientModule : AbpModule
{

}
