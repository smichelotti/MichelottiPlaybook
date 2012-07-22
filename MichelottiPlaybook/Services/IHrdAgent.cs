using System;
using System.Collections.Generic;
using MichelottiPlaybook.Models;

namespace MichelottiPlaybook.Services
{
    public interface IHrdAgent
    {
        List<HrdIdentityProvider> GetProviders(string contextUri);
    }
}
