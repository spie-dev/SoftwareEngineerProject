using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}"); 

            routes.MapRoute(
                name: "Profiles",
                url: "profiles/view/{id}",
                defaults: new
                {
                    controller = "profile",
                    action = "profileView",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Edit",
                url: "Edit",
                defaults: new { controller = "Profile", action = "Edit" }
            );

            routes.MapRoute(
                name: "Search",
                url: "Search/{id}",
                defaults: new { controller = "Search", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login",
                url: "Login",
                defaults: new { controller = "Home", action = "Login" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
