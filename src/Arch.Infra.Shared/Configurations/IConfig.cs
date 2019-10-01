using System;
using System.Collections.Generic;
using System.Text;

namespace Arch.Infra.Shared.Configurations
{
    public interface IConfig
    {
        List<(Type domain, Type command)> GetCommandDomains();
        void AddCommandDomain((Type domain, Type command) commandDomain);
    }
}
