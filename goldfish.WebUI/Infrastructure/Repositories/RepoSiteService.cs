using SX.WebCore.SxRepositories;
using goldfish.WebUI.ViewModels;
using goldfish.WebUI.Models;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System;
using System.Text;
using SX.WebCore.ViewModels;
using System.Threading.Tasks;

namespace goldfish.WebUI.Infrastructure.Repositories
{
    public sealed class RepoSiteService : SxRepoMaterial<SiteService, VMSiteService>
    {
        public RepoSiteService() : base(MvcApplication.ModelCoreTypeProvider[nameof(SiteService)]) { }

        public VMSiteService GetByTitleUrl(string titleUrl)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var data = connection.Query<VMSiteService, SxVMMaterialCategory, SxVMAppUser, SxVMPicture, SxVMSeoTags, VMSiteService>("dbo.get_material_by_url NULL, NULL, NULL, @titleUrl, @mct", (s, c, u, p, st) =>
                {
                    s.Category = c;
                    s.User = u;
                    s.FrontPicture = p;
                    s.SeoTags = st;
                    return s;
                }, new
                {
                    titleUrl = titleUrl,
                    mct = MvcApplication.ModelCoreTypeProvider[nameof(SiteService)]
                }, splitOn:"Id");

                return data.SingleOrDefault();
            }
        }
        public async Task<VMSiteService> GetByTitleUrlAsync(string titleUrl)
        {
            return await Task.Run(() => {
                return GetByTitleUrl(titleUrl);
            });
        }

        protected sealed override Action<SqlConnection, SiteService> ChangeMaterialBeforeSelect
        {
            get
            {
                return (connection, model) =>
                {
                    var existModel = connection.Query<SiteService>("dbo.enrich_site_services @ids", new { ids = model.Id.ToString() }).SingleOrDefault();
                    if (existModel != null && Equals(model.Id, existModel.Id))
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