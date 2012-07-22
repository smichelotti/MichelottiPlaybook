using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace MichelottiPlaybook
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            //routes.MapRoute(
            //    name: "Playbook",
            //    url: "Playbook/{categorySlug}",
            //    defaults: new { controller = "Playbook", action = "Category" }
            //);

            //HACK: need to make these into route constraints
            routes.MapRoute(
                name: "WorkoutsStatic1",
                url: "Workouts/Guard",
                defaults: new { controller = "Workouts", action = "Guard" }
            );

            routes.MapRoute(
                name: "WorkoutsStatic2",
                url: "Workouts/BigMan",
                defaults: new { controller = "Workouts", action = "BigMan" }
            );

            routes.MapRoute(
                name: "Playbook",
                url: "Playbook/{categorySlug}",
                defaults: new { controller = "Video", action = "Index", playType = "Play" },
                constraints: new { playType = "Play" }
            );

            routes.MapRoute(
                name: "Workouts",
                url: "Workouts/{categorySlug}",
                defaults: new { controller = "Video", action = "Index", playType = "Drill" },
                constraints: new { playType = "Drill" }
            );
          

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}