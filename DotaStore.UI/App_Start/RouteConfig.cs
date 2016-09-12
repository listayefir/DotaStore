﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DotaStore.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "",
                defaults: new
                {
                    controller = "Items",
                    action = "List",
                    category = (string) null,
                    page = 1
                }
            );

            routes.MapRoute(
                 null,
                "Page{page}",
                new 
                {
                    controller = "Items",
                    action = "List",
                    category = (string) null
                },
                new
                {
                    page = @"\d+"
                }
            );

            routes.MapRoute(null,
                "{category}",
                new { controller = "Items", action = "List", page = 1 }
                );
            routes.MapRoute(null,
            "{category}/Page{page}",
            new { controller = "Items", action = "List" },
            new { page = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Items", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
