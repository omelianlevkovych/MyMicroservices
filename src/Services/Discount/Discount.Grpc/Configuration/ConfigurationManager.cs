using Discount.Grpc.Configuration.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace Discount.Grpc.Configuration
{
    public class ConfigurationManager : IConfigurationManager
    {
        private readonly IConfiguration configuration;

        public ConfigurationManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public T GetConfiguration<T>(string key)
        {
            if (!TryGetConfiguration<T>(key, out var result))
            {
                throw new ArgumentNullException(nameof(result));
            }

            return result;
        }

        public T GetConfigurationOrDefault<T>(string key, T defaultValue)
        {
            if (TryGetConfiguration<T>(key, out var result))
            {
                return result;
            }

            return defaultValue;
        }

        private bool TryGetConfiguration<T>(string key, out T value)
        {
            value = configuration.GetValue<T>(key);

            return value is not null;
        }
    }
}
