using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloCore.Config
{
    public interface IConfigWatcher
    {
        void OnChange();
    }
}
