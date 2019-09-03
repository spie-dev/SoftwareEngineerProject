using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                name: "ProfilesSearch",
                url: "profiles/search/{id}",
                defaults: new
                {
                    controller = "ProfileSearch",
                    action = "Search",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "ProfileEdit",
                url: "profiles/edit/{id}",
                defaults: new
                {
                    controller = "Profile",
                    action = "Edit",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "ProfileSave",
                url: "profiles/save/{id}",
                defaults: new
                {
                    controller = "Profile",
                    action = "Save",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}
