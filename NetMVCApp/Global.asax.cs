using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NetMVCApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
    /// <summary>
    /// uygulaman�n ilk aya�a kald��� main dosyas�
    /// </summary>
        protected void Application_Start()
        
    {
      // areas ile alt klas�r bazl� bir y�netim varsa onlar� uygulama
            AreaRegistration.RegisterAllAreas();
      // default route uygula
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
