using ApolloConfig;
using ApolloCore.Config;
using Microsoft.Extensions.Options;
using System;
using System.Text.Json;

namespace apollonet.Watchers
{
    public class WhiteListConfigWatcher : ConfigWatcherBase<Value>, IConfigWatcher
    {
        public WhiteListConfigWatcher(IOptionsMonitor<Value> monitor) : base(monitor)
        {
        }

        protected override void RaiseChange(Value config, string arg)
        {
            Console.WriteLine($"配置发生变动 新值为：{JsonSerializer.Serialize(config)}");
        }
    }
}
