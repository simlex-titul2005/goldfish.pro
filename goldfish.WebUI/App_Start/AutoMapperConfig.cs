using AutoMapper;
using goldfish.WebUI.Models;
using goldfish.WebUI.ViewModels;

namespace goldfish.WebUI
{
    public class AutoMapperConfig
    {
        public static void Register(IMapperConfigurationExpression cfg)
        {
            //site service
            cfg.CreateMap<SiteService, VMSiteService>();
            cfg.CreateMap<VMSiteService, SiteService>();

            //site project
            cfg.CreateMap<SiteProject, VMSiteProject>();
            cfg.CreateMap<VMSiteProject, SiteProject>();

            //site project security item
            cfg.CreateMap<SiteProjectSecurityItem, VMSiteProjectSecurityItem>();
            cfg.CreateMap<VMSiteProjectSecurityItem, SiteProjectSecurityItem>();
        }
    }
}