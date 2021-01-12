//using System;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Text;
//using static ApolloCore.Config.ConfigMonitManager;

//namespace ApolloCore.Config
//{
//    public class ConfigListenerTrigger
//    {
//        private readonly IServiceProvider _serviceProvider;
//        private readonly ConcurrentDictionary<Type, MonitorHandler> _monitors;

//        public ConfigListenerTrigger(
//            ConcurrentDictionary<Type, MonitorHandler> monitors,
//            IServiceProvider serviceProvider
//            )
//        {
//            _serviceProvider = serviceProvider;
//            _monitors = monitors;
//        }

//        public void Trigger()
//        {

//        }
//    }
//}
