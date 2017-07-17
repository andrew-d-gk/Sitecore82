using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;

namespace Sitecore82.Factory
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {

        private IKernel _kernel;
        public NinjectControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public override void ReleaseController(IController controller)
        {
            _kernel.Release(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (IController)_kernel.Get(controllerType);
        }
    }
}