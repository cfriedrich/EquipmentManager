﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EquipmentManager.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //    routes.MapRoute(null,
            //        "",
            //        new { controller = "Item", action = "ListItems", category = (string)null, page = 1 });

            //    routes.MapRoute(null, "Page{page}", new { controller = "Item", action = "ListItems", category = (string)null, page = 1 },
            //        new { page = @"\d+" });

            //    routes.MapRoute(null, "{category}", new { controller = "Item", action = "ListItems", page = 1 });

            //    routes.MapRoute(null, "{category}/Page{page}", new { controller = "Item", action = "ListItems" },
            //        new { page = @"\d+" });

            //    routes.MapRoute(null, "{controller}/{action}");
            //}


            routes.MapRoute(
                name: null,
                url: "Home/ListItems/Page{page}",
                defaults: new { controller = "Home", action = "ListItems" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}