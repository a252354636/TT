using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;

using System.Threading;
using DataDTO.Request.Merge;
using DataDTO.EnumCode;

namespace WebMvc.Controllers
{
    [Authorize]
    public class MergeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Succeed()
        {
            return View();
        }
        [HttpGet]
        public JsonResult MergeWithoutList(QueryMergePayInfo query)
        {
            query.StatusList = new List<int>() {
                (int)MergeStatusEnum.AfterMerger,
                (int)MergeStatusEnum.HasUpdated,
                (int)MergeStatusEnum.NeedUpdated
            };
            Service.MergeService orderInfo = new Service.MergeService();
            var ret = orderInfo.GetMergePayInfoList(query);

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public JsonResult Pay(int MergeId, string Url)
        //{
        //    Service.MergeService service = new Service.MergeService();
        //    var ret = service.MergeRemitSucceed(MergeId, Url);
        //    if (ret.success)
        //    {
        //    }
        //    return Json(ret);
        //}
    }
}