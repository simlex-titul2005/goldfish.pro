using SX.WebCore.Repositories;
using System;
using System.Text;

namespace goldfish.WebUI.Infrastructure.Repositories
{
    public sealed class RepoPicture : SxRepoPicture
    {
        protected override Action<StringBuilder> InsertNotFreePictures
        {
            get
            {
                return (sb)=> { };
            }
        }
    }
}