/**
 * Copyright 2018 d-fens GmbH
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Diagnostics.Contracts;

namespace Net.Appclusive.WPF.UI.Attributes
{
    /// <summary>
    /// This attribute is used to define the resource name of a specific enum value
    /// for resource file based translation
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ResourceNameAttribute : Attribute
    {
        /// <summary>
        /// Holds the name of the resource file entry
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Constructor used to init a ResourceNameAttribute
        /// </summary>
        /// <param name="name">Name of the resource file entry</param>
        public ResourceNameAttribute(string name)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(name));

            Name = name;
        }
    }
}
