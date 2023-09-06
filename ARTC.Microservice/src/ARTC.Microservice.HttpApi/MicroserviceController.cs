using ARTC.Microservice.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ARTC.Microservice;

public abstract class MicroserviceController : AbpControllerBase
{
    protected MicroserviceController()
    {
        LocalizationResource = typeof(MicroserviceResource);
    }
}
