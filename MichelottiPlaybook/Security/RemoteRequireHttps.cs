using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MichelottiPlaybook.Security
{
    /// <summary>
    /// Only require HTTPS if this is running remotely on the server. Don't required HTTPS for local dev.
    /// </summary>
    public class RemoteRequireHttpsAttribute : RequireHttpsAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext != null && filterContext.HttpContext.Request.IsLocal)
            {
                return;
            }

            base.OnAuthorization(filterContext);
        }
    }
}