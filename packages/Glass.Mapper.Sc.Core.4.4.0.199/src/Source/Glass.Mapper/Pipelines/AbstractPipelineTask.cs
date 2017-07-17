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

using System;

namespace Glass.Mapper.Pipelines
{
    /// <summary>
    /// Interface IPipelineTask
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractPipelineTask<T>  where T: AbstractPipelineArgs
    {

        public string Name { get; protected set; }

        protected Action<T> NextAction { get; private set; }

        public void SetNext(Action<T> next)
        {
            NextAction = next;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        public virtual void Execute(T args)
        {
            Next(args);
        }
        public void Next(T args)
        {
            if (NextAction != null)
            {
                NextAction(args);
            }
        }
    }
}




