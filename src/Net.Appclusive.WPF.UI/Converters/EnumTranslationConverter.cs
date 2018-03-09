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
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Reflection;
using Net.Appclusive.WPF.UI.Attributes;
using Net.Appclusive.WPF.UI.Properties;

namespace Net.Appclusive.WPF.UI.Converters
{
    public class EnumTranslationCoverter : EnumConverter
    {
        internal const string MISSING_RESOURCE_ENTRY = "RESOURCE-ENTRY-MISSING";

        public EnumTranslationCoverter(Type type)
            : base(type)
        {
            Contract.Requires(null != type);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            Contract.Assert(null != context);
            Contract.Assert(null != culture);
            Contract.Assert(null != destinationType);

            if (destinationType != typeof(string))
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }

            if (value != null)
            {
                FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
                Contract.Assert(null != fieldInfo);

                var attributes = (ResourceNameAttribute[])fieldInfo.GetCustomAttributes(typeof(ResourceNameAttribute), false);
                if (attributes.Length < 1)
                {
                    return value.ToString();
                }

                var resourceName = attributes[0].Name;
                var localizedText = Resources.ResourceManager.GetString(resourceName, culture);

                if (string.IsNullOrWhiteSpace(localizedText))
                {
                    return MISSING_RESOURCE_ENTRY;
                }

                return localizedText;
            }

            return string.Empty;
        }
    }
}
