using BLL;
using Ninject;
using NinjectCommon;
using Parsing;
using System.Web.Mvc;

namespace FinallyTaskForASP.Controllers
{
    public class ShopsController : Controller
    {
        AllSitesParsing sitesParsing = new AllSitesParsing();
        private static readonly IParsingLogic parsingLogic = NinjectClass.Kernel.Get<IParsingLogic>();
        // GET: Shops
        public ActionResult Index()
        {
            sitesParsing.Parsing();
            return View(parsingLogic.GetShops());
        }

        public ActionResult OrderByDiscount(string discount)
        {
            return View("Index", parsingLogic.GetShopByDiscount(discount));
        }
    }
}