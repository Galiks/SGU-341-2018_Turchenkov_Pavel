using BLL;
using DAO;
using Ninject;
using Parsing;

namespace NinjectCommon
{
    public static class NinjectClass
    {
        private static readonly IKernel _kernel = new StandardKernel();

        public static IKernel Kernel => _kernel;

        public static void Registration()
        {
            _kernel.Bind<ILetyShopsDAO>().To<LetyShopsDAO>();
            _kernel.Bind<ILetyShopsLogic>().To<LetyShopsLogic>();

            _kernel.Bind<ISiteParsing>().To<LetyShopsParsing>();
            
        }
    }
}
