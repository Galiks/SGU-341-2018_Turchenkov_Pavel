using BLL;
using Ninject;
using NinjectCommon;
using System.Web.Mvc;

namespace FinallyTaskForASP.Controllers
{
    public class SignInController : Controller
    {
        private static readonly IParsingLogic parsingLogic = NinjectClass.Kernel.Get<IParsingLogic>();
        // GET: SignIn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Authorization(string login, string password)
        {
            var user = parsingLogic.GetPersonByName(login);

            if (user != null && password == user.Password)
            {
                return RedirectToRoute(new { controller = "Shops", action = "Index" });
            }

            return RedirectToRoute(new { controller = "Registration", action = "Index" });
        }
    }
}