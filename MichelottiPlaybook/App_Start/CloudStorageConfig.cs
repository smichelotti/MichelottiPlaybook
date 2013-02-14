using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MichelottiPlaybook.Models;
using Microsoft.WindowsAzure;
//using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;

namespace MichelottiPlaybook
{
    public static class CloudStorageConfig
    {
        public static void Configure()
        {
            CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) => configSetter(ConfigSettingPublisher.GetSettingValue(configName)));
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