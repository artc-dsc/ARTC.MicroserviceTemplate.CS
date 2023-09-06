using Volo.Abp.Reflection;

namespace ARTC.Microservice.Permissions;

public class MicroservicePermissions
{
    public const string GroupName = "Microservice";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(MicroservicePermissions));
    }
}
