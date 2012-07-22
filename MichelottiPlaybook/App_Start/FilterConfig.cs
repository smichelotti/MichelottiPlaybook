using System.Web;
using System.Web.Mvc;
using MichelottiPlaybook.Security;

namespace MichelottiPlaybook
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RemoteRequireHttpsAttribute());
        }
    }
}