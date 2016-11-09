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
            routes.MapRoute(name: null, url: "Employees", defaults: new { controller = "Employees", action = "List" }, namespaces: _dafaultNamespaces);

            //manuals
            routes.MapRoute(name: null, url: "Manuals", defaults: new { controller = "Manuals", action = "List", page = 1 }, namespaces: _dafaultNamespaces);
            routes.MapRoute(name: null, url: "Manuals/{cat}/{titleUrl}", defaults: new { controller = "Manuals", action = "Details" }, namespaces: _dafaultNamespaces);

            //site projects
            routes.MapRoute(name: null, url: "SiteProjects", defaults: new { controller = "SiteProjects", action = "List", page = 1 }, namespaces: _dafaultNamespaces);
            routes.MapRoute(name: null, url: "SiteProjects/page{page}", defaults: new { controller = "SiteProjects", action = "List", page = 1 }, namespaces: _dafaultNamespaces);
            routes.MapRoute(name: null, url: "SiteProjects/{titleUrl}", defaults: new { controller = "SiteProjects", action = "Details" }, namespaces: _dafaultNamespaces);

            //site services
            routes.MapRoute(name: null, url: "SiteServices", defaults: new { controller = "SiteServices", action = "List", page = 1 }, namespaces: _dafaultNamespaces);
            routes.MapRoute(name: null, url: "SiteServices/page{page}", defaults: new { controller = "SiteServices", action = "List", page = 1 }, namespaces: _dafaultNamespaces);
            routes.MapRoute(name: null, url: "SiteServices/{titleUrl}", defaults: new { controller = "SiteServices", action = "Details" }, namespaces: _dafaultNamespaces);
        }

        public static void PostRouteAction(RouteCollection routes)
        {

        }
    }
}