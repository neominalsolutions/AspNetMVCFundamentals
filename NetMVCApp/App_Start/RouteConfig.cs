using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NetMVCApp
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      //routes.MapRoute(name: "Kategori", url: "iletisim-bilgileri", new { controller = "Home", action = "Contact" });
      routes.MapMvcAttributeRoutes(); // attribute routing özelliği ile mvc action üstüne yazılan route değerine göre işlem yap.

      routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

    }
  }
}
