using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApolloCore.Client
{
    public class ApolloClient : IApolloClient
    {
        private readonly IConfiguration _configuration;
        public ApolloClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration => _configuration;

        public TConfig Get<TConfig>(string key)
            where TConfig : new()
        {
            var section = _configuration.GetSection(key);
            var config = InstanceHelper<TConfig>.CreateInstance();
            section.Bind(config);
            return config;
        }

        public async Task<TConfig> GetAsync<TConfig>(string key)
            where TConfig : new()
        {
            return await Task.FromResult(Get<TConfig>(key));
        }

        public string GetValue(string key)
        {
            return _configuration.GetValue<string>(key);
        }



        public async Task<string> GetValueAsync(string key)
        {
            return await Task.FromResult(GetValue(key));
        }

        internal class InstanceHelper<T>
            where T : new()
        {
            private static readonly Expression<Func<T>> ctorExpression = () => new T();

            internal static T CreateInstance()
            {
                var f = ctorExpression.Compile();
                return f();
            }
        }
        
    }
}
