//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using Ninject;
//using System.Reflection;

//namespace Sitecore82.Controllers.Factory
//{
//    public class NinjectKernelFactory
//    {
//        public IKernel Create()
//        {
//            return LoadAssembliesIntoKernel(new StandardKernel());
//        }

//        private IKernel LoadAssembliesIntoKernel(IKernel kernel)
//        {
//            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
//            {
//                try
//                {
//                    kernel.Load(assembly);
//                }
//                catch (Exception)
//                {
//                    //Empty Catch used because ninject have problem
//                    //with loading some of the Sitecore MVC assemblies.
//                    // Method .ToString()
//                }
//            }
//            return kernel;
//        }
//    }
//}