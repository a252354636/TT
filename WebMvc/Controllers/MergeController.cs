﻿using System;
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
using Microsoft.AspNet.Identity.Owin;

namespace WebMvc.Controllers
{
    [Authorize]
    public class MergeController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public MergeController()
        {
        }

        public MergeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
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
            TT.Service.MergeService orderInfo = new TT.Service.MergeService();
            var ret = orderInfo.GetMergePayInfoList(query);

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Pay(int MergeId, string Url)
        {
            TT.Service.MergeService service = new TT.Service.MergeService();
            var ret = service.MergeRemitSucceed(MergeId, Url);
            if (ret.success)
            {
            }
            return Json(ret);
        }
        [HttpPost]
        public  JsonResult MergeBankInfoReject(int MergeId, string RepulseRemark)
        {
            TT.Service.MergeService service = new TT.Service.MergeService();
            var ret = service.MergeBankInfoReject(MergeId,RepulseRemark);
            if (ret.success)
            {
            }
            return Json(ret);
        }
    }
}