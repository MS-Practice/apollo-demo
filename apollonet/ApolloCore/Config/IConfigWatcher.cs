using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloCore.Config
{
    /// <summary>
    /// 不支持对单个key的监听变化
    /// <see cref="https://github.com/ctripcorp/apollo.net/issues/125"/>
    /// </summary>
    public interface IConfigWatcher
    {
        void OnChange();
    }
}
