using BLL;
using DAO;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectCommon
{
    public class Ninject
    {
        private static readonly IKernel kernel = new StandardKernel();

        public static IKernel Kernel => kernel;

        public static void Registration()
        {
            Kernel.Bind<ILetyShopsDAO>().To<LetyShopsDAO>();
            Kernel.Bind<ILetyShopsLogic>().To<LetyShopsLogic>();
        }
    }
}
