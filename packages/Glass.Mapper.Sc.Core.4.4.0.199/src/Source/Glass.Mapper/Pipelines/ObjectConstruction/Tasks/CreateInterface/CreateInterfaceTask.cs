/*
   Copyright 2012 Michael Edwards
 
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 
*/ 
//-CRE-


using Castle.DynamicProxy;

namespace Glass.Mapper.Pipelines.ObjectConstruction.Tasks.CreateInterface
{
    /// <summary>
    /// Creates classes based on interfaces
    /// </summary>
    public class CreateInterfaceTask : AbstractObjectConstructionTask
    {
        private static volatile  ProxyGenerator _generator;

        /// <summary>
        /// Initializes static members of the <see cref="CreateInterfaceTask"/> class.
        /// </summary>
        static CreateInterfaceTask()
        {
            _generator = new ProxyGenerator();
        }

        public CreateInterfaceTask()
        {
            Name = "CreateInterfaceTask";
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        public override void Execute(ObjectConstructionArgs args)
        {
            if (args.Result== null 
                && args.Configuration.Type.IsInterface) 
            {
                args.Result = _generator.CreateInterfaceProxyWithoutTarget(args.Configuration.Type, new InterfacePropertyInterceptor(args));
                args.Counters.ProxyModelsCreated++;
            }

            base.Execute(args);
        }
    }
}




