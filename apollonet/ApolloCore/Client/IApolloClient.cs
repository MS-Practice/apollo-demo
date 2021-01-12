using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApolloCore.Client
{
    public interface IApolloClient
    {
        IConfiguration Configuration { get; }
        Task<TConfig> GetAsync<TConfig>(string key) where TConfig : new();
        TConfig Get<TConfig>(string key) where TConfig : new();
        Task<string> GetValueAsync(string key);
        string GetValue(string key);
    }
}
