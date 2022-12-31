# ServiceDiscovery with Consul
Common Service Discovery class library with Consul. This class library can be published as a Nuget or can be referenced directly in the project.

[![Build Status](https://dev.azure.com/bm1905/SharedLibraries/_apis/build/status/bm1905.ServiceDiscovery?branchName=master)](https://dev.azure.com/bm1905/SharedLibraries/_build/latest?definitionId=2&branchName=master)

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
