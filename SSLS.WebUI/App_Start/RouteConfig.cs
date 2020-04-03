using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SSLS.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                null,
                "",
                new { controller = "Book", action = "List", categoryId = 0, page = 1 }
                );
            routes.MapRoute(
                null,
                "page{page}",
                new { controller = "Book", action = "List", categoryId = 0 },
                new { page = @"\d+" }
                );
            routes.MapRoute(
                null,
                "cId{categoryId}",
                new { controller = "Book", action = "List", page = 1 },
                new { categoryId = @"\d+" }
           );

            routes.MapRoute(
               null,
               "cId{categoryId}/page{page}",
               new { controller = "Book", action = "List" },
               new { categoryId = @"\d+", page = @"\d+" }
               );
            routes.MapRoute(
             null,
             "Id{Id}",
             new { controller = "Book", action = "Detail", categoryId = 0, page = 1 },
             new { Id = @"\d+" }
        );
            routes.MapRoute(
            null,
            "page{page}/Id{Id}",
            new { controller = "Book", action = "Detail", categoryId = 0 },
            new { page = @"\d+", Id = @"\d+" }
       );
            routes.MapRoute(
               null,
               "cId{categoryId}/Id{Id}",
               new { controller = "Book", action = "Detail", page = 1 },
               new { categoryId = @"\d+", Id = @"\d+" }
          );
            routes.MapRoute(
              null,
              "cId{categoryId}/page{page}/Id{Id}",
              new { controller = "Book", action = "Detail", },
              new { categoryId = @"\d+", page = @"\d+", Id = @"\d+" }
         );

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}"

            );
        }
    }
}
