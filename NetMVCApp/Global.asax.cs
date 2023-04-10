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
    /// uygulamanýn ilk ayaða kaldýðý main dosyasý
    /// </summary>
        protected void Application_Start()
        
    {
      // areas ile alt klasör bazlý bir yönetim varsa onlarý uygulama
            AreaRegistration.RegisterAllAreas();
      // default route uygula
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
