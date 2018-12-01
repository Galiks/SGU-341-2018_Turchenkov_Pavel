using BLL;
using Ninject;
using NinjectCommon;
using System.Web.Mvc;

namespace FinallyTaskForASP.Controllers
{
    public class RegistrationController : Controller
    {
        private static readonly IParsingLogic parsingLogic = NinjectClass.Kernel.Get<IParsingLogic>();
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignOn(string login, string password)
        {
            if (parsingLogic.AddPerson(login, password))
            {
                return RedirectToRoute(new { controller = "SignIn", action = "Index" });
            }

            return View();
        }
    }
}