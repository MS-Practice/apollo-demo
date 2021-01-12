using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace ApolloCore.Config
{
    //public class ConfigMonitManager
    //{
    //    public delegate void MonitorHandler(Type type, string name);

    //    private static readonly ConcurrentDictionary<object, MonitorHandler> handlers = new ConcurrentDictionary<object, MonitorHandler>();
    //    public static void RegistMonitHandler<TConfig>(MonitorHandler handler)
    //    {
    //        handlers.TryAdd(typeof(TConfig), handler);
    //    }

    //    public static MonitorHandler GetMonitorHandler(Type type)
    //    {
    //        if (handlers.TryGetValue(type, out var handler))
    //        {
    //            return handler;
    //        }
    //        return default;
    //    }

    //    internal class HandlerWrapper
    //    {

    //    }
    //}
}
