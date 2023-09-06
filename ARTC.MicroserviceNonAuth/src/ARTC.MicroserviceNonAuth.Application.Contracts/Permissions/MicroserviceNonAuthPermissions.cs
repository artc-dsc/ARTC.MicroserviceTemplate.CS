using Volo.Abp.Reflection;

namespace ARTC.MicroserviceNonAuth.Permissions;

public class MicroserviceNonAuthPermissions
{
    public const string GroupName = "MicroserviceNonAuth";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(MicroserviceNonAuthPermissions));
    }
}
