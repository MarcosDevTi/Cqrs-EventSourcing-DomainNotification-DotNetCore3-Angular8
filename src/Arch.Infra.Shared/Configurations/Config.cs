using System;
using System.Collections.Generic;
using System.Text;

namespace Arch.Infra.Shared.Configurations
{
    public class Config : IConfig
    {
        private readonly List<(Type domain, Type command)> commandDomains;
        public Config() => commandDomains = new List<(Type domain, Type command)>();
        public void AddCommandDomain((Type domain, Type command) commandDomain) => commandDomains.Add(commandDomain);
        public List<(Type domain, Type command)> GetCommandDomains() => commandDomains;
    }
}
