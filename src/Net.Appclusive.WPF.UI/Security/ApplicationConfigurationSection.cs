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

using System.Configuration;

namespace Net.Appclusive.WPF.UI.Security
{
    public class ApplicationConfigurationSection : ConfigurationSection
    {
        internal const string SECTION_NAME = "applicationConfiguration";

        private const string DEFAULT_DOMAIN_ATTRIBUTE_NAME = "defaultDomain";
        private const string APPCLUSIVE_BASE_URI_ATTRIBUTE_NAME = "appclusiveBaseUri";

        //<configuration>

        //<!-- Configuration section-handler declaration area. -->
        //  <configSections>
        //  	<section 
        //  		name="applicationConfiguration" 
        //  		type="Net.Appclusive.WPF.UI.Security.ApplicationConfigurationSection, Net.Appclusive.WPF.UI" 
        //  		allowLocation="true" 
        //  		allowDefinition="Everywhere" 
        //  	/>
        //      <!-- Other <section> and <sectionGroup> elements. -->
        //  </configSections>

        //  <!-- Configuration section settings area. -->
        //  <applicationConfiguration defaultDomain="dfch" appclusiveBaseUri="https://example.com/api />

        //</configuration>

        [ConfigurationProperty(DEFAULT_DOMAIN_ATTRIBUTE_NAME, IsRequired = true)]
        public string DefaultDomain
        {
            get
            {
                return (string)this[DEFAULT_DOMAIN_ATTRIBUTE_NAME];
            }
            set
            {
                this[DEFAULT_DOMAIN_ATTRIBUTE_NAME] = value;
            }
        }

        [ConfigurationProperty(APPCLUSIVE_BASE_URI_ATTRIBUTE_NAME, IsRequired = true)]
        public string AppclusiveBaseUri
        {
            get
            {
                return (string)this[APPCLUSIVE_BASE_URI_ATTRIBUTE_NAME];
            }
            set
            {
                this[APPCLUSIVE_BASE_URI_ATTRIBUTE_NAME] = value;
            }
        }
    }
}
