using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Text;

namespace goldfish.WebUI.Controllers
{
    public sealed class OrdersController : SxOrdersController<SX.WebCore.DbModels.SxOrder, SxVMOrder>
    {
        [HttpPost, AllowAnonymous]
        public override async Task<ActionResult> Add(SxVMOrder model)
        {
            if (!ModelState.IsValid) return View(model);

            var data = Mapper.Map<SxVMOrder, SX.WebCore.DbModels.SxOrder>(model);
            var order = await Repo.CreateAsync(data);

            var sb = new StringBuilder();
            sb.AppendFormat("<div>Заказ от: {0}</div><br/>", order.DateCreate);
            sb.AppendFormat("<div>Заказчик: {0}</div><br/>", order.ClientName);
            sb.AppendFormat("<div>Адрес заказчика: {0}</div><br/>", order.ClientEmail);
            sb.AppendFormat("<div>Телефон заказчика: {0}</div><br/>", order.ClientPhone);
            sb.AppendFormat("<div>Дополнительно: {0}</div><br/>", order.Text);

            var mailManager = new SX.WebCore.Managers.SxAppMailManager();
            var result=await mailManager.SendNoReplyMail(sb.ToString(), new string[] { "simlex.dev.2014@gmail.com" }, "Заказ с goldfish.pro" );

            ViewBag.Message = result;
            return View();
        }
    }
}