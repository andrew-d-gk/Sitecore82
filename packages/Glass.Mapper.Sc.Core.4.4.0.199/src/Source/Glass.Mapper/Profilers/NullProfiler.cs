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

namespace Glass.Mapper.Profilers
{
    /// <summary>
    /// Class NullProfiler
    /// </summary>
    public class NullProfiler : IPerformanceProfiler
    {
        
        public static NullProfiler Instance { get; private set; }

        static NullProfiler()
        {
            Instance = new NullProfiler();
        }

        private NullProfiler() { }

        /// <summary>
        /// Starts the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Start(string key)
        {
        }

        /// <summary>
        /// Ends the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void End(string key)
        {
        }

        public void IndentIncrease()
        {
        }

        public void IndentDecrease()
        {
        }
    }
}




