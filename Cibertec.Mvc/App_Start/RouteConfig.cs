using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cibertec.Mvc
{
    //Se define la tabla de enrutamiento del sitio web
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Indica al motor de ruteo que los request que involucren recursos axd
            //no se van a tomar en cuenta, van a ser gestionados directamente
            //por IIS
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //ruta estatica
            //routes.MapRoute(
            //    name: "Clientes",
            //    url: "Clientes",
            //    defaults: new { controller = "Customer", action = "Index"}
            //);

            //ruta dinamica
            //routes.MapRoute(
            //    name: "ClientesDinamica",
            //    url: "Clientes/{id}/{action}",
            //    defaults: new { controller = "Customer", action = "Details" },
            //    constraints: new {id=@"\d+"}
            //);

            //ruta seo
            //localhost/angel
            //localhost/
            //routes.MapRoute(
            //    name: "ClientesSEO",
            //    url: "{clientName}",
            //    defaults: new { controller = "Customer", action = "DetailsName" }
            //    //,
            //        //clientName = UrlParameter.Optional }

            //);
            //localhost

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
