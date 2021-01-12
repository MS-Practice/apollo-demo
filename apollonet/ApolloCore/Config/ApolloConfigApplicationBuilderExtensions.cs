using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloCore.Config
{
    public static class ApolloConfigApplicationBuilderExtensions
    {
        public static void StartConfigChangeListening(this IApplicationBuilder app)
        {
            using IServiceScope cope = app.ApplicationServices.CreateScope();
            var services = app.ApplicationServices.GetServices<IConfigWatcher>();
            foreach (var service in services)
            {
                service.OnChange();
            }

        }
    }
}
