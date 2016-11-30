using goldfish.WebUI.Infrastructure;
using goldfish.WebUI.Models;
using SX.WebCore.MvcApplication;
using System;
using System.Collections.Generic;

namespace goldfish.WebUI
{
    public class MvcApplication : SxMvcApplication
    {
        private static readonly Dictionary<string, byte> _customModelCoreTypes = new Dictionary<string, byte> {
            [nameof(SiteProject)] = 100,
            [nameof(SiteService)] = 101
        };

        /// <summary>
        /// "Точка входа" в приложение.
        /// Запускается самым первым при старте приложения.
        /// Здесь происходит вся инициализация переменных, свойст, кеша и пр.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Application_Start(object sender, EventArgs e)
        {
            var args = new SxApplicationEventArgs(
                    defaultSiteName: "goldfish.pro",
                    getDbContextInstance: () => new DbContext(),
                    customModelCoreTypes: _customModelCoreTypes,
                    getModelCoreTypeName: getModelCoreTypeName
                )
            {
                WebApiConfigRegister = WebApiConfig.Register,
                MapperConfigurationExpression = AutoMapperConfig.Register,
                DefaultControllerNamespaces = new string[] { "goldfish.WebUI.Controllers" },
                PreRouteAction = RouteConfig.PreRouteAction,
                PostRouteAction = RouteConfig.PostRouteAction
            };

            base.Application_Start(sender, args);
        }

        private static string getModelCoreTypeName(byte key)
        {
            switch(key)
            {
                case 1:
                    return "Статья";
                case 2:
                    return "Новость";
                case 4:
                    return "Мануал";
                case 100:
                    return "Проект";
                case 101:
                    return "Услуга";
                default:
                    return null;
            }
        }
    }
}
