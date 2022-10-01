using System.Threading;
using System.Threading.Tasks;
using Consul;
using Microsoft.Extensions.Hosting;

namespace ServiceDiscovery
{
    /// <summary>
    /// ServiceDiscoveryHostedService class that extends IHostedService
    /// </summary>
    public class ServiceDiscoveryHostedService : IHostedService
    {
        private readonly IConsulClient _client;
        private readonly ServiceConfig _config;
        private string _registrationId;

        /// <summary>
        /// ServiceDiscoveryHostedService constructor
        /// </summary>
        /// <param name="client">IConsulClient</param>
        /// <param name="config">ServiceConfig</param>
        public ServiceDiscoveryHostedService(IConsulClient client, ServiceConfig config)
        {
            _client = client;
            _config = config;
        }

        /// <summary>
        /// Starts the hosted service
        /// </summary>
        /// <param name="cancellationToken">CancellationToken</param>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _registrationId = $"{_config.ServiceName}-{_config.ServiceId}";

            var registration = new AgentServiceRegistration
            {
                ID = _registrationId,
                Name = _config.ServiceName,
                Address = _config.ServiceAddress.Host,
                Port = _config.ServiceAddress.Port,
                // Check = new AgentCheckRegistration()
                // {
                //     HTTP = $"{_config.ServiceAddress}/healthcheck",
                //     Interval = TimeSpan.FromSeconds(10)
                // }
            };

            await _client.Agent.ServiceDeregister(registration.ID, cancellationToken);
            await _client.Agent.ServiceRegister(registration, cancellationToken);
        }

        /// <summary>
        /// Stops the hosted service
        /// </summary>
        /// <param name="cancellationToken">CancellationToken</param>
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _client.Agent.ServiceDeregister(_registrationId, cancellationToken);
        }
    }
}

