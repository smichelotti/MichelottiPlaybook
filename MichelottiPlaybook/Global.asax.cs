using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Web;
using Microsoft.IdentityModel.Web.Configuration;

namespace MichelottiPlaybook
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            CloudStorageConfig.Configure();

            //FederatedAuthentication.ServiceConfigurationCreated += OnServiceConfigurationCreated;
        }

        private void OnServiceConfigurationCreated(object sender, ServiceConfigurationCreatedEventArgs e)
        {
            if (e.ServiceConfiguration.ServiceCertificate == null)
            {
                throw new ApplicationException("No site certificate; is it set up in web.config?");
                // Make sure you've got the service certificate set up in the web.config:
                // <serviceCertificate>
                //   <certificateReference x509FindType="FindByThumbprint" findValue="4653AE813BA15DFFB027E3AC147004B2D24F472B" />
                // </serviceCertificate>
            }

            List<CookieTransform> sessionTransforms = new List<CookieTransform>(new CookieTransform[] 
            {
                new DeflateCookieTransform(), 
                new RsaEncryptionCookieTransform(e.ServiceConfiguration.ServiceCertificate),
                new RsaSignatureCookieTransform(e.ServiceConfiguration.ServiceCertificate)  
            });
            SessionSecurityTokenHandler sessionHandler = new SessionSecurityTokenHandler(sessionTransforms.AsReadOnly());

            e.ServiceConfiguration.SecurityTokenHandlers.AddOrReplace(sessionHandler);
        }
    }
}