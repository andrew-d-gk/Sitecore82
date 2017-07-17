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


using System.Linq;

namespace Glass.Mapper.Pipelines.ConfigurationResolver.Tasks.StandardResolver
{
    /// <summary>
    /// Class ConfigurationStandardResolverTask
    /// </summary>
    public class ConfigurationStandardResolverTask : AbstractConfigurationResolverTask
    {
        public ConfigurationStandardResolverTask()
        {
            Name = "ConfigurationStandardResolverTask";
        }
        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        public override void Execute(ConfigurationResolverArgs args)
        {
            if (args.Result == null)
            {
                args.Result = args.Context[args.RequestedType];
            }
            base.Execute(args);
        }
    }
}




