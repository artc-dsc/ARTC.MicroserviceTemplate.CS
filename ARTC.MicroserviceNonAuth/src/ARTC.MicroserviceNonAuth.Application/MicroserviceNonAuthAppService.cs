using ARTC.MicroserviceNonAuth.Localization;
using Volo.Abp.Application.Services;

namespace ARTC.MicroserviceNonAuth;

public abstract class MicroserviceNonAuthAppService : ApplicationService
{
    protected MicroserviceNonAuthAppService()
    {
        LocalizationResource = typeof(MicroserviceNonAuthResource);
        ObjectMapperContext = typeof(MicroserviceNonAuthApplicationModule);
    }
}
