using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloCore.Config
{
    public class ApolloConfig
    {
        public string AppId { get; set; }
        public string Cluster { get; set; }
        public string MetaServer { get; set; }
        public string[] ConfigServer { get; set; }
        public string[] Namespaces { get; set; }
    }
}
