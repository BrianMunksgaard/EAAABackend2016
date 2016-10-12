using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Routing.Constraints;

namespace RouteStuff
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Q2
            routes.MapRoute(
                name: "idrequired",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index" }
            );

            // Q3
            routes.MapRoute(
                name: "idoptional",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = "100" }
            );

            // Q4-1
            routes.MapRoute(
               name: "idintegeronly",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               constraints: new { id = new IntRouteConstraint() }
               //constraints: new { id = @"\d+" }
            );

            // Q4-2
            // Requires routes.MapMvcAttributeRoutes()
            routes.MapRoute(
                name: "idintegeronly2",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            

            /*
            * Annotate action method as:
            * [Route("/artist/xxx/{id:int}")]
            * public string GetArtist(int id) {...}
            */

            // Q5
            routes.MapRoute(
                name: "idrangeonly",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { id = new RangeRouteConstraint(10, 100)}
            );

            // Q6
            routes.MapRoute(
                name: "anynumberofsegments",
                url: "{controller}/{action}/{id}/{*catchall}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // Q7
            routes.MapRoute(
                name: "shop",
                url: "shop/{controller}/{category}/{title}",
                defaults: new { action = "index", category = "", title = "" }
            );

            routes.MapRoute(
              name: "shop2",
              url: "shop/{producttype}/{category}/{title}",
              defaults: new { controller = "product", action = "index", category = "", title = "" }
            );

            /* Q1: Default route match and no-match.
                Match:  localhost (domain name only)
                        /home/index
                        /home/index?id=1
                        /home/index/1
                        /home
        
             No-match:  /home/kurt
                        /home/index/1/kurt
                        /kurt/home
                        /index/home
            */
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
