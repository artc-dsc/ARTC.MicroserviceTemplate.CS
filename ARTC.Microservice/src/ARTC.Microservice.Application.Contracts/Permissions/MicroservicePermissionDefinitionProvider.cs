using ARTC.Microservice.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ARTC.Microservice.Permissions;

public class MicroservicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MicroservicePermissions.GroupName, L("Permission:Microservice"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MicroserviceResource>(name);
    }
}
