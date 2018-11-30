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
            _kernel.Bind<IParsingDAO>().To<ParsingDAO>();
            _kernel.Bind<IParsingLogic>().To<ParsingLogic>();
            _kernel.Bind<ISiteParsing>().To<SiteParsing>();
            
        }
    }
}
