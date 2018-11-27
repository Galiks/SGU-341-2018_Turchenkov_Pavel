using BLL;
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
        private static ILetyShopsLogic letyShopsLogic;
        private static ISiteParsing siteParsing;

        public HomeController()
        {
            NinjectClass.Registration();

            letyShopsLogic = NinjectClass.Kernel.Get<ILetyShopsLogic>();
            siteParsing = NinjectClass.Kernel.Get<ISiteParsing>();
        }

        public ActionResult Index()
        {
            siteParsing.Parsing();
            return View(siteParsing.ShowData());
        }
    }
}