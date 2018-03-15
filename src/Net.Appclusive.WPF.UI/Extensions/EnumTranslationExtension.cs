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
using System.Globalization;
using Net.Appclusive.WPF.UI.Converters;

namespace Net.Appclusive.WPF.UI.Extensions
{
    public static class EnumTranslationExtension
    {
        public static string GetTranslatedValue(this Enum value)
        {
            var enumTranslationConverter = new EnumTranslationCoverter(value.GetType());

            return enumTranslationConverter.ConvertTo(new DummyDescriptorContext(), CultureInfo.CurrentCulture, value, typeof(string)) as string;
        }
    }

    public class DummyDescriptorContext : ITypeDescriptorContext
    {
        // ReSharper disable once UnassignedGetOnlyAutoProperty
        public IContainer Container { get; }
        // ReSharper disable once UnassignedGetOnlyAutoProperty
        public object Instance { get; }
        // ReSharper disable once UnassignedGetOnlyAutoProperty
        public PropertyDescriptor PropertyDescriptor { get; }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public bool OnComponentChanging()
        {
            throw new NotImplementedException();
        }

        public void OnComponentChanged()
        {
            throw new NotImplementedException();
        }
    }
}
