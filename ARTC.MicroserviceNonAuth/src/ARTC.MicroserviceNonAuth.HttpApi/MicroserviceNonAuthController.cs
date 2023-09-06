using ARTC.MicroserviceNonAuth.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ARTC.MicroserviceNonAuth;

public abstract class MicroserviceNonAuthController : AbpControllerBase
{
    protected MicroserviceNonAuthController()
    {
        LocalizationResource = typeof(MicroserviceNonAuthResource);
    }
}
