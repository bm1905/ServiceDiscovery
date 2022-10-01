using System;
using Microsoft.Extensions.Configuration;

namespace ServiceDiscovery
{
    /// <summary>
    /// ServiceConfigExtensions Method
    /// </summary>
    public static class ServiceConfigExtension
    {
        /// <summary>
        /// Get the service configuration from config file. Following should be part of config file and must be provided
        /// ServiceConfig:ServiceDiscoveryAddress - Service Discovery Address URI
        /// ServiceConfig:ServiceAddress - Service Address URI
        /// ServiceConfig:ServiceName - Service Name of type string
        /// ServiceConfig:ServiceId - Unique Service ID of type string
        /// </summary>
        /// <param name="configuration">Configuration</param>
        /// <returns>ServiceConfig instance</returns>
        /// <exception cref="ArgumentNullException">ArgumentNullException exception</exception>
        public static ServiceConfig GetServiceConfig(this IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var serviceConfig = new ServiceConfig
            {
                ServiceDiscoveryAddress = configuration.GetValue<Uri>("ServiceConfig:ServiceDiscoveryAddress"),
                ServiceAddress = configuration.GetValue<Uri>("ServiceConfig:ServiceAddress"),
                ServiceName = configuration.GetValue<string>("ServiceConfig:ServiceName"),
                ServiceId = configuration.GetValue<string>("ServiceConfig:ServiceId")
            };

            return serviceConfig;
        }
    }
}
