using ApolloConfig;
using ApolloCore.Config;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace apollonet.Watchers
{
    public class ModConfigWatcher : ConfigWatcherBase<ModConfig>, IConfigWatcher
    {
        public ModConfigWatcher(IOptionsMonitor<ModConfig> monitor) : base(monitor)
        {
        }

        protected override void RaiseChange(ModConfig config, string arg)
        {
            if (_monitor.CurrentValue.AppId != config.AppId
                || _monitor.CurrentValue.Platform != config.Platform
                || _monitor.CurrentValue.RequestId != config.RequestId
                || _monitor.CurrentValue.Userflag != config.Userflag)
                Console.WriteLine($"配置发生变动 新值为：{JsonSerializer.Serialize(config)}");
        }
    }
}
