using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Mvc.Controllers;
using Sitecore.Pipelines;
using ControllerBuilder = System.Web.Mvc.ControllerBuilder;

namespace Sitecore82.Factory
{
    public class InitializeNinjectControllerFactory
    {
        public virtual void Process(PipelineArgs args)
        {
            SetControllerFactory(args);
        }

        protected virtual void SetControllerFactory(PipelineArgs args)
        {
            NinjectKernelFactory kernelFactory = new NinjectKernelFactory();
            NinjectControllerFactory ninjectControllerFactory = new NinjectControllerFactory(kernelFactory.Create());
            SitecoreControllerFactory sitecoreControllerFactory = new SitecoreControllerFactory(ninjectControllerFactory);
            ControllerBuilder.Current.SetControllerFactory(sitecoreControllerFactory);
        }
    }
}