using System;

namespace ServiceDiscovery
{
    /// <summary>
    /// ServiceConfig configuration properties
    /// </summary>
    public class ServiceConfig
    {
        /// <summary>
        /// Service Discovery Address
        /// </summary>
        public Uri ServiceDiscoveryAddress { get; set; }
        /// <summary>
        /// Service Address
        /// </summary>
        public Uri ServiceAddress { get; set; }
        /// <summary>
        /// Service Name
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// Service Id
        /// </summary>
        public string ServiceId { get; set; }
    }
}