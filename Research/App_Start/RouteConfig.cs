using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Research
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapM01();
            routes.MapM02();
            routes.MapM03();

            routes.MapRoute(
                name: "CResearch",
                url: "CResearch/{action}",
                defaults: new { controller = "CResearch", action = "C01" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

    public static class RouteCollectionExtension
    {
        public static void MapM01(this RouteCollection routes)
        {
            routes.MapRoute(
                name: "MResearch1",
                url: "MResearch/M01/1",
                defaults: new { controller = "MResearch", action = "M01" }
            );

            routes.MapRoute(
                name: "MResearch2",
                url: "MResearch/M01",
                defaults: new { controller = "MResearch", action = "M01" }
            );

            routes.MapRoute(
                name: "MResearch3",
                url: "MResearch",
                defaults: new { controller = "MResearch", action = "M01" }
            );

            routes.MapRoute(
                name: "MResearch4",
                url: "",
                defaults: new { controller = "MResearch", action = "M01" }
            );

            routes.MapRoute(
                name: "MResearch5",
                url: "V2/MResearch/M01",
                defaults: new { controller = "MResearch", action = "M01" }
            );

            routes.MapRoute(
                name: "MResearch6",
                url: "V3/MResearch/X/M01",
                defaults: new { controller = "MResearch", action = "M01" }
            );

        }

        public static void MapM02(this RouteCollection routes)
        {
            routes.MapRoute(
                name: "MResearch21",
                url: "V2",
                defaults: new { controller = "MResearch", action = "M02" }
            );

            routes.MapRoute(
                name: "MResearch22",
                url: "V2/MResearch",
                defaults: new { controller = "MResearch", action = "M02" }
            );

            routes.MapRoute(
                name: "MResearch23",
                url: "V2/MResearch/M02",
                defaults: new { controller = "MResearch", action = "M02" }
            );

            routes.MapRoute(
                name: "MResearch24",
                url: "MResearch/M02",
                defaults: new { controller = "MResearch", action = "M02" }
            );

            routes.MapRoute(
                name: "MResearch25",
                url: "V3/MResearch/X/M02",
                defaults: new { controller = "MResearch", action = "M02" }
            );
        }

        public static void MapM03(this RouteCollection routes)
        {
            routes.MapRoute(
                name: "MResearch31",
                url: "V3",
                defaults: new { controller = "MResearch", action = "M03" }
            );

            routes.MapRoute(
                name: "MResearch32",
                url: "V3/MResearch/X",
                defaults: new { controller = "MResearch", action = "M03" }
            );

            routes.MapRoute(
                name: "MResearch33",
                url: "V3/MResearch/X/M03",
                defaults: new { controller = "MResearch", action = "M03" }
            );
        }
    }
}
