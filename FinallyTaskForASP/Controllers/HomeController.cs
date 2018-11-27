using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinallyTaskForASP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<string> list = new List<string>() { "qwe", "asd", "zxc" };
            return View(list);
        }
    }
}