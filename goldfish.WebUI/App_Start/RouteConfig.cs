using System.Web.Mvc;
using System.Web.Routing;

namespace goldfish.WebUI
{
    public class RouteConfig
    {
        private static readonly string[] _dafaultNamespaces = new string[] { "goldfish.WebUI.Controllers" };

        public static void PreRouteAction(RouteCollection routes)
        {
            //employess
            routes.MapRoute(name: null, url: "Employees/{nikname}", defaults: new { controller = "Employees", action = "Details" }, namespaces: _dafaultNamespaces);

            //site projects
            routes.MapRoute(name: null, url: "SiteProjects/{titleUrl}", defaults: new { controller = "SiteProjects", action = "Details" }, namespaces: _dafaultNamespaces);

            //site services
            routes.MapRoute(name: null, url: "SiteServices/{titleUrl}", defaults: new { controller = "SiteServices", action = "Details"}, namespaces: _dafaultNamespaces);
        }

        public static void PostRouteAction(RouteCollection routes)
        {

        }
    }
}