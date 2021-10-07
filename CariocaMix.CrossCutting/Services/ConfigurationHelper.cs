using CariocaMix.CrossCutting.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace CariocaMix.CrossCutting.Services
{
    public class ConfigurationHelper : IConfigurationHelper
    {
        private readonly IConfiguration _configuration;

        public ConfigurationHelper(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string GetString(string key) =>
            GetValue<string>(key);

        public T GetValue<T>(string key) =>
            _configuration.GetValue<T>(key);
    }
}
