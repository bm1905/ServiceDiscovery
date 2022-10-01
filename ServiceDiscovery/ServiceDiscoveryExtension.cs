using System;
using Consul;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ServiceDiscovery
{
    /// <summary>
    /// ServiceDiscoveryExtension method
    /// </summary>
    public static class ServiceDiscoveryExtension
    {
        /// <summary>
        /// Register Consul Services.
        /// This method will register ServiceConfig as a singleton.
        /// This method will register ConsulClient as a singleton.
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="serviceConfig">Instance of ServiceConfig</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        public static void RegisterConsulServices(this IServiceCollection services, ServiceConfig serviceConfig)
        {
            if (serviceConfig == null)
            {
                throw new ArgumentNullException(nameof(serviceConfig));
            }

            var consulClient = CreateConsulClient(serviceConfig);

            services.AddSingleton(serviceConfig);
            services.AddSingleton<IHostedService, ServiceDiscoveryHostedService>();
            services.AddSingleton<IConsulClient, ConsulClient>(_ => consulClient);
        }

        private static ConsulClient CreateConsulClient(ServiceConfig serviceConfig)
        {
            return new ConsulClient(config =>
            {
                config.Address = serviceConfig.ServiceDiscoveryAddress;
            });
        }
    }
}