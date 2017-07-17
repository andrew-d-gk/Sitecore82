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

namespace Glass.Mapper.Configuration
{
    /// <summary>
    /// Class ChildrenConfiguration
    /// </summary>
    public class ChildrenConfiguration : AbstractPropertyConfiguration
    {

        public ChildrenConfiguration()
        {
            IsLazy = true;
        }

        /// <summary>
        /// Indicates if children should be loaded lazily. Default value is true. If false all children will be loaded when the containing object is created.
        /// </summary>
        /// <value><c>true</c> if this instance is lazy; otherwise, <c>false</c>.</value>
        public virtual bool IsLazy
        {
            get;
            set;
        }

        /// <summary>
        /// Indicates the type should be inferred from the item template
        /// </summary>
        /// <value><c>true</c> if [infer type]; otherwise, <c>false</c>.</value>
        public virtual bool InferType
        {
            get;
            set;
        }

        protected override AbstractPropertyConfiguration CreateCopy()
        {
            return new ChildrenConfiguration();
        }

        protected override void Copy(AbstractPropertyConfiguration copy)
        {
            var config = copy as ChildrenConfiguration;

            config.IsLazy = IsLazy;
            config.InferType = InferType;

            base.Copy(copy);
        }
    }
}




