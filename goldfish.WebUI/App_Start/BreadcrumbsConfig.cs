using goldfish.WebUI.ViewModels;
using SX.WebCore.MvcControllers.Abstract;
using SX.WebCore.ViewModels;
using System.Collections.Generic;

namespace goldfish.WebUI
{
    public class BreadcrumbsConfig
    {
        public static void FillBreadcrumbs(SxBaseController controller, HashSet<SxVMBreadcrumb> breadcrumbs)
        {
            breadcrumbs.Add(new SxVMBreadcrumb { Title = "Главная", Url = controller.Url.Action("Index", "Home") });

            switch (controller.SxControllerName)
            {
                default: break;

                case "employees":
                    fillEmployeesControllerBreadcrumbs(controller, ref breadcrumbs);
                    break;

                case "home":
                    fillHomeControllerBreadcrumbs(controller, ref breadcrumbs);
                    break;

                case "orders":
                    fillOrdersControllerBreadcrumbs(controller, ref breadcrumbs);
                    break;

                case "siteservices":
                    fillSiteServicesControllerBreadcrumbs(controller, ref breadcrumbs);
                    break;

                case "siteprojects":
                    fillSiteProjectsControllerBreadcrumbs(controller, ref breadcrumbs);
                    break;

                case "sitereviews":
                    fillSiteReviewsControllerBreadcrumbs(controller, ref breadcrumbs);
                    break;
            }
        }

        private static void fillEmployeesControllerBreadcrumbs(SxBaseController controller, ref HashSet<SxVMBreadcrumb> breadcrumbs)
        {
            breadcrumbs.Add(new SxVMBreadcrumb { Title = "Сотрудники", Url = controller.Url.Action("List", "Employees") });
            switch (controller.SxActionName)
            {
                case "details":
                    var nikname = controller.SxRouteDataValues["nikname"];
                    breadcrumbs.Add(new SxVMBreadcrumb { Title = (string)nikname, Url = controller.Url.Action("Details", "Employees", new { nikname = nikname }) });
                    break;
            }
        }

        private static void fillHomeControllerBreadcrumbs(SxBaseController controller, ref HashSet<SxVMBreadcrumb> breadcrumbs)
        {
            switch (controller.SxActionName)
            {
                case "aboutus":
                    breadcrumbs.Add(new SxVMBreadcrumb { Title = "О нас", Url = controller.Url.Action("AboutUs", "Home") });
                    break;
            }
        }

        private static void fillOrdersControllerBreadcrumbs(SxBaseController controller, ref HashSet<SxVMBreadcrumb> breadcrumbs)
        {
            switch (controller.SxActionName)
            {
                case "add":
                    breadcrumbs.Add(new SxVMBreadcrumb { Title = "Сделать заказ", Url = controller.Url.Action("Add", "Orders") });
                    break;
            }
        }

        private static void fillSiteServicesControllerBreadcrumbs(SxBaseController controller, ref HashSet<SxVMBreadcrumb> breadcrumbs)
        {
            breadcrumbs.Add(new SxVMBreadcrumb { Title = "Услуги сайта", Url = controller.Url.Action("List", "SiteServices") });
            switch (controller.SxActionName)
            {
                case "details":
                    var model = controller.SxModel as VMSiteService;
                    breadcrumbs.Add(new SxVMBreadcrumb { Title = model.Title, Url = controller.Url.Action("Details", "SiteServices", new { titleUrl = model.Title }) });
                    break;
            }
        }

        private static void fillSiteProjectsControllerBreadcrumbs(SxBaseController controller, ref HashSet<SxVMBreadcrumb> breadcrumbs)
        {
            breadcrumbs.Add(new SxVMBreadcrumb { Title = "Проекты сайта", Url = controller.Url.Action("List", "SiteProjects") });
            switch (controller.SxActionName)
            {
                case "details":
                    var model = controller.SxModel as VMSiteProject;
                    breadcrumbs.Add(new SxVMBreadcrumb { Title = model.Title, Url = controller.Url.Action("Details", "SiteProjects", new { titleUrl = model.Title }) });
                    break;
            }
        }

        private static void fillSiteReviewsControllerBreadcrumbs(SxBaseController controller, ref HashSet<SxVMBreadcrumb> breadcrumbs)
        {
            switch (controller.SxActionName)
            {
                case "add":
                    breadcrumbs.Add(new SxVMBreadcrumb { Title = "Оставить отзыв", Url = controller.Url.Action("Add", "SiteReviews") });
                    break;
            }
        }
    }
}