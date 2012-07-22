using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using MichelottiPlaybook.Models;
using Microsoft.IdentityModel.Web;

namespace MichelottiPlaybook.Services
{
    public class HrdAgent : IHrdAgent
    {
        public List<HrdIdentityProvider> GetProviders(string contextUri)
        {
            WSFederationAuthenticationModule fam = FederatedAuthentication.WSFederationAuthenticationModule;
            HrdRequest request = new HrdRequest(fam.Issuer, fam.Realm, context: contextUri);

            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string response = client.DownloadString(request.GetUrlWithQueryString());

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var providers = serializer.Deserialize<List<HrdIdentityProvider>>(response);
            foreach (var item in providers)
            {
                if (item.Name.StartsWith("Windows Live"))
                {
                    item.Name = "Windows Live";
                }
            }

            return providers;
        }
    }
}