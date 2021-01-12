using ApolloCore.Client;
using ApolloCore.Config;
using Com.Ctrip.Framework.Apollo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.Extensions.Hosting
{
    public static class ApolloExtensions
    {
        public static IHostBuilder ConfigureApolloConfiguration(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureAppConfiguration(builder =>
                builder.AddApolloConfiguration()
            );
        }


        public static IApolloConfigurationBuilder AddApolloConfiguration(this IConfigurationBuilder builder) =>
            builder.AddApollo(builder.Build().GetSection("apollo"));

    }

    public static class ApolloServiceCollections
    {
        public static ApolloConfigOptionBuilder AddApolloClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IApolloClient, ApolloClient>();
            return new ApolloConfigOptionBuilder(services, configuration);
        }
    }
}
