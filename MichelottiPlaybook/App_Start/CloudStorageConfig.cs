using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MichelottiPlaybook.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;

namespace MichelottiPlaybook
{
    public static class CloudStorageConfig
    {
        public static void Configure()
        {
            if (RoleEnvironment.IsAvailable)
            {
                //var account = CloudStorageAccount.FromConfigurationSetting("AzureStorage");
                //var tableClient = new CloudTableClient(account.TableEndpoint.AbsoluteUri, account.Credentials);
                //CloudTableClient.CreateTablesFromModel(typeof(PlaybookTableContext), account.TableEndpoint.AbsoluteUri, account.Credentials);
            }
            else
            {
                CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) => configSetter(ConfigSettingPublisher.GetSettingValue(configName)));

            }
        }

        private static class ConfigSettingPublisher
        {
            public static string GetSettingValue(string key)
            {
                return ConfigurationManager.AppSettings.Get(key);
            }
        }
    }
}