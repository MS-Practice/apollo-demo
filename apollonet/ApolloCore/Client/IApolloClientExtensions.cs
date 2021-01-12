using System.Text.Json;
using System.Threading.Tasks;

namespace ApolloCore.Client
{
    public static class IApolloClientExtensions
    {
        public static TConfig GetValue<TConfig>(this IApolloClient client, string key)
        {
            var value = client.GetValue(key);
            return JsonSerializer.Deserialize<TConfig>(value,new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        public static async Task<TConfig> GetValueAsync<TConfig>(this IApolloClient client, string key)
        {
            var value = await client.GetValueAsync(key);
            return JsonSerializer.Deserialize<TConfig>(value, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }
    }
}
