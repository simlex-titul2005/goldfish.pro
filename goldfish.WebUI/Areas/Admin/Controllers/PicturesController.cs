using goldfish.WebUI.Infrastructure.Repositories;
using SX.WebCore.MvcControllers;

namespace goldfish.WebUI.Areas.Admin.Controllers
{
    public sealed class PicturesController : SxPicturesController
    {
        private static RepoPicture _repo = new RepoPicture();
        public PicturesController():base()
        {
            if (Repo == null || (Repo as RepoPicture) == null)
                Repo = _repo;
        }
    }
}