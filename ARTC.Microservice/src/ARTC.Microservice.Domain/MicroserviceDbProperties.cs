namespace ARTC.Microservice;

public static class MicroserviceDbProperties
{
    public static string DbTablePrefix { get; set; } = "Microservice";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Microservice";
}
