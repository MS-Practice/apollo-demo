using ApolloConfig;
using ApolloCore.Client;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace apollonet.Controllers
{
    [ApiController]
    [Route("apollo")]
    public class LoadApolloConfigureController : Controller
    {
        private readonly IApolloClient _apolloClient;
        public LoadApolloConfigureController(IApolloClient apolloClient)
        {
            _apolloClient = apolloClient;
        }

        [HttpGet("{key}")]
        public async Task<string> GetAsync(string key)
        {
            var obj = await _apolloClient.GetAsync<ModConfig>(key);
            var obj2 = await _apolloClient.GetValueAsync<ModConfig>(key);
            return await Task.FromResult(JsonSerializer.Serialize(obj));
        }
    }
}
