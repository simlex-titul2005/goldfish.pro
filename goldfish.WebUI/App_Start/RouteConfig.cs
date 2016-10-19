using System.Web.Mvc;
using System.Web.Routing;

namespace goldfish.WebUI
{
    public class RouteConfig
    {
        private static readonly string[] _dafaultNamespaces = new string[] { "goldfish.WebUI.Controllers" };

        public static void PreRouteAction(RouteCollection routes)
        {
            routes.MapRoute(name: null, url: "SiteServices/{titleUrl}", defaults: new { controller = "SiteServices", action = "Details"}, namespaces: _dafaultNamespaces);
        }

        public static void PostRouteAction(RouteCollection routes)
        {

        }
    }
}