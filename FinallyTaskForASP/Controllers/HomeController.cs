using BLL;
using FinallyTaskForASP.Models;
using Ninject;
using NinjectCommon;
using Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinallyTaskForASP.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILetyShopsLogic letyShopsLogic = NinjectClass.Kernel.Get<ILetyShopsLogic>();
        private static readonly ISiteParsing siteParsing = NinjectClass.Kernel.Get<ISiteParsing>();

        public ActionResult Index()
        {
            siteParsing.Parsing();

            return View(siteParsing.ShowData());
        }
    }
}