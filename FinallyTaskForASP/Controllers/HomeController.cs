using BLL;
using Entity;
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
        AllSitesParsing sitesParsing = new AllSitesParsing();
        private static readonly IParsingLogic parsingLogic = NinjectClass.Kernel.Get<IParsingLogic>();

        public ActionResult Index()
        {
            sitesParsing.Parsing();
            return View(parsingLogic.GetShops());
        }
    }
}