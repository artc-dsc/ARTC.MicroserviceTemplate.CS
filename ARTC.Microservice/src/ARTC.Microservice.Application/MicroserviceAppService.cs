using ARTC.Microservice.Localization;
using Volo.Abp.Application.Services;

namespace ARTC.Microservice;

public abstract class MicroserviceAppService : ApplicationService
{
    protected MicroserviceAppService()
    {
        LocalizationResource = typeof(MicroserviceResource);
        ObjectMapperContext = typeof(MicroserviceApplicationModule);
    }
}
