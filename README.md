# ServiceDiscovery with Consul
Common Service Discovery class library with Consul. This class library can be published as a Nuget or can be referenced directly in the project.

## Usage
In `Startup.cs` file, use the following code snippet.
```cs
public class Startup
{
    private readonly IConfiguration _config;

    public Startup(IConfiguration config)
    {
        _config = config;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddServiceDiscovery(config);
    }

    private static void AddServiceDiscovery(this IServiceCollection services, IConfiguration config)
    {
        ServiceConfig serviceConfig = config.GetServiceConfig();
        services.RegisterConsulServices(serviceConfig);
    }
}
```

Then add the following to the configuration file `appsettings.YOUR ENV.json`
```json
"ServiceConfig": {
    "ServiceDiscoveryAddress": "https://URL",
    "ServiceName": "unique-service-name",
    "ServiceId": "unique-service-id",
    "ServiceAddress": "https://URL"
}
```