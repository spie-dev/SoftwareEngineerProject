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
                name: "ProfileEdit",
                url: "profiles/edit/{id}",
                defaults: new
                {
                    controller = "profile",
                    action = "edit",
                    id = UrlParameter.Optional
                }
            );
            

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
                name: "HomeCountroller",
                url: "Home/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AccountManager", action = "Login", id = UrlParameter.Optional }
            );


        }
    }
}
