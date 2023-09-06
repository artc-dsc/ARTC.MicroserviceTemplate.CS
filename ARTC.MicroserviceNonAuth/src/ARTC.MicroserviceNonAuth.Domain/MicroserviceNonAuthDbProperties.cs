namespace ARTC.MicroserviceNonAuth;

public static class MicroserviceNonAuthDbProperties
{
    public static string DbTablePrefix { get; set; } = "MicroserviceNonAuth";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "MicroserviceNonAuth";
}
