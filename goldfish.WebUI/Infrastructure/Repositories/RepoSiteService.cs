using SX.WebCore.Repositories;
using goldfish.WebUI.ViewModels;
using goldfish.WebUI.Models;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System;
using System.Text;

namespace goldfish.WebUI.Infrastructure.Repositories
{
    public sealed class RepoSiteService : SxRepoMaterial<SiteService, VMSiteService>
    {
        public RepoSiteService() : base(MvcApplication.ModelCoreTypeProvider[nameof(SiteService)]) { }

        public VMSiteService GetByTitleUrl(string titleUrl)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var data = connection.Query<VMSiteService>("dbo.get_site_service_by_title_url @titleUrl", new { titleUrl = titleUrl });
                return data.SingleOrDefault();
            }
        }

        protected sealed override Action<SqlConnection, SiteService> ChangeMaterialBeforeSelect
        {
            get
            {
                return (connection, model) => {
                    var existModel = connection.Query<SiteService>("dbo.enrich_site_services @ids", new { ids = model.Id.ToString() }).SingleOrDefault();
                    if(existModel!=null && Equals(model.Id, existModel.Id))
                    {
                        model.MainPageIconCssClass = existModel.MainPageIconCssClass;
                    }
                };
            }
        }

        protected sealed override Action<SqlConnection, VMSiteService[]> ChangeMaterialsAfterSelect
        {
            get
            {
                return (connection, data) =>
                {
                    var sb = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        sb.AppendFormat(",{0}", data[i].Id);
                    }
                    sb.Remove(0, 1);

                    var cssClasses = connection.Query<VMSiteService>("dbo.enrich_site_services @ids", new { ids = sb.ToString() }).ToArray();
                    VMSiteService item = null;
                    for (int i = 0; i < data.Length; i++)
                    {
                        item = data[i];
                        item.MainPageIconCssClass = cssClasses.SingleOrDefault(x => x.Id == item.Id).MainPageIconCssClass;
                    }
                };
            }
        }
    }
}