using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure;

namespace MichelottiPlaybook.Models
{
    public static class ContextFactory
    {
        public static PlaybookTableContext CreateContext()
        {
            var account = CloudStorageAccount.FromConfigurationSetting("AzureStorage");
            return new PlaybookTableContext(account.TableEndpoint.AbsoluteUri, account.Credentials);
        }
    }
}