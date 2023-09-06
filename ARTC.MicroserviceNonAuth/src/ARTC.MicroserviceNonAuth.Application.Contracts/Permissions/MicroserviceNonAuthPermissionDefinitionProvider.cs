using ARTC.MicroserviceNonAuth.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ARTC.MicroserviceNonAuth.Permissions;

public class MicroserviceNonAuthPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MicroserviceNonAuthPermissions.GroupName, L("Permission:MicroserviceNonAuth"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MicroserviceNonAuthResource>(name);
    }
}
