﻿using goldfish.WebUI.ViewModels;
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

                case "manuals":
                    fillManualsControllerBreadcrumbs(controller, ref breadcrumbs);
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

        private static void fillManualsControllerBreadcrumbs(SxBaseController controller, ref HashSet<SxVMBreadcrumb> breadcrumbs)
        {
            breadcrumbs.Add(new SxVMBreadcrumb { Title="Руководства", Url=controller.Url.Action("List", "Manuals")});
            SxVMMaterialCategory category = null;
            SxVMAppUser author = null;
            SxVMMaterialTag tag = null;
            switch (controller.SxActionName)
            {
                case "list":
                    category = controller.ViewBag.Category;
                    if (category != null)
                        breadcrumbs.Add(new SxVMBreadcrumb() { Title= string.Format("Категория: {0}", category.Title), Url=controller.Url.Action("List", "Manuals", new { cat=category.Id }) });

                    author = controller.ViewBag.Author;
                    if(author!=null)
                        breadcrumbs.Add(new SxVMBreadcrumb() { Title = string.Format("Автор: {0}", author.NikName), Url = controller.Url.Action("List", "Manuals", new { auth = author.NikName }) });

                    tag = controller.ViewBag.Tag;
                    if(tag!=null)
                        breadcrumbs.Add(new SxVMBreadcrumb() { Title = string.Format("Тег: {0}", tag.Title), Url = controller.Url.Action("List", "Manuals", new { tag = tag.Id }) });

                    break;
                case "details":
                    var model = (SxVMManual)controller.SxModel;
                    category = model.Category;
                    if(category!=null)
                        breadcrumbs.Add(new SxVMBreadcrumb { Title = category.Title, Url = controller.Url.Action("List", "Manuals", new { category=category.Id }) });
                    breadcrumbs.Add(new SxVMBreadcrumb { Title = model.Title, Url= model.GetUrl(controller.Url) });
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