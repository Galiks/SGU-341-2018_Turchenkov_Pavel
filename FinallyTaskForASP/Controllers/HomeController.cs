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
        private static readonly IParsingLogic parsingLogic = NinjectClass.Kernel.Get<IParsingLogic>();
        private static readonly ISiteParsing siteParsing = NinjectClass.Kernel.Get<ISiteParsing>();

        public ActionResult Index()
        {
            parsingLogic.AddShop("LetyShops");

            siteParsing.Parsing();

            var result = siteParsing.ShowData();

            foreach (var item in result)
            {
                parsingLogic.AddData((LetyShops)item);
            }

            return View(siteParsing.ShowData());
        }
    }
}