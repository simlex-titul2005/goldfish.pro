using AutoMapper;
using goldfish.WebUI.Models;
using goldfish.WebUI.ViewModels;
using SX.WebCore.ViewModels;

namespace goldfish.WebUI
{
    public class AutoMapperConfig
    {
        public static void Register(IMapperConfigurationExpression cfg)
        {
            //site service
            cfg.CreateMap<SiteService, VMSiteService>();
            cfg.CreateMap<VMSiteService, SiteService>();
            cfg.CreateMap<SxVMSiteService, VMSiteService>();
        }
    }
}