using ApolloConfig;
using ApolloCore.Config;
using Microsoft.Extensions.Options;
using System;
using System.Text.Json;

namespace apollonet.Watchers
{
    public class WhiteListConfigWatcher : ConfigWatcherBase<KeyValueConfig>, IConfigWatcher
    {
        public WhiteListConfigWatcher(IOptionsMonitor<KeyValueConfig> monitor) : base(monitor)
        {
        }

        protected override void RaiseChange(KeyValueConfig config, string arg)
        {
            Console.WriteLine($"配置发生变动 新值为：{JsonSerializer.Serialize(config)}");
        }
    }
}
