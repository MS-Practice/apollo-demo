using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ApolloCore.Config
{
    public abstract class ConfigWatcherBase<TConfig> : IConfigWatcher
    {
        protected readonly IOptionsMonitor<TConfig> _monitor;
        public ConfigWatcherBase(
            IOptionsMonitor<TConfig> monitor)
        {
            _monitor = monitor;
        }

        public void OnChange()
        {
            _monitor.OnChange(RaiseChange);
        }

        abstract protected void RaiseChange(TConfig config, string arg);
        //{
        //    Console.Write($"{config.GetType().FullName} 配置发生变动 新值为：{JsonSerializer.Serialize(arg)}");
        //}
    }
}
