using goldfish.WebUI.Infrastructure;
using goldfish.WebUI.Models;
using SX.WebCore.MvcApplication;
using System;
using System.Collections.Generic;

namespace goldfish.WebUI
{
    public class MvcApplication : SxMvcApplication
    {
        /// <summary>
        /// "Точка входа" в приложение.
        /// Запускается самым первым при старте приложения.
        /// Здесь происходит вся инициализация переменных, свойст, кеша и пр.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Application_Start(object sender, EventArgs e)
        {
            var args = new SxApplicationEventArgs() {
                GetDbContextInstance = () => { return new DbContext(); },
                WebApiConfigRegister=WebApiConfig.Register,
                MapperConfigurationExpression=AutoMapperConfig.Register,
                DefaultControllerNamespaces=new string[] { "goldfish.WebUI.Controllers"},
                PreRouteAction=RouteConfig.PreRouteAction,
                PostRouteAction=RouteConfig.PostRouteAction,
                DefaultSiteName="goldfish.pro",
                CustomModelCoreTypes=new Dictionary<string, byte> {
                    [nameof(SiteProject)]=100,
                    [nameof(SiteService)]=101
                }
            };

            base.Application_Start(sender, args);
        }
    }
}
