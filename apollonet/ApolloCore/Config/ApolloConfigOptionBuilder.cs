using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace ApolloCore.Config
{
    public class ApolloConfigOptionBuilder
    {
        private readonly IServiceCollection _services;
        private readonly IConfiguration _configuration;
        public ApolloConfigOptionBuilder(
            IServiceCollection services,
            IConfiguration configuration)
        {
            _services = services ?? throw new ArgumentNullException(nameof(_services));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(_configuration));
            _services.AddOptions();
        }

        public ApolloConfigOptionBuilder AddMonitor<TConfig>(string sectionName)
            where TConfig : class
        {
            _services.Configure<TConfig>(_configuration.GetSection(sectionName));
            return this;
        }

        public ApolloConfigOptionBuilder RegisterWatcherAssemblyTypes(params Assembly[] assemblies)
        {
            if (assemblies.Length > 0)
            {
                var types = assemblies.SelectMany(assembly => assembly.GetTypes().Where(p => typeof(IConfigWatcher).IsAssignableFrom(p)));
                foreach (var t in types)
                {
                    _services.Add(new ServiceDescriptor(typeof(IConfigWatcher), t, ServiceLifetime.Transient));
                }
            }
            return this;
        }
    }
}