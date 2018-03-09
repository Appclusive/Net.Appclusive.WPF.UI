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
using System.Windows.Markup;

namespace Net.Appclusive.WPF.UI.Extensions
{
    /// <summary>
    /// For more details see http://brianlagunas.com/a-better-way-to-data-bind-enums-in-wpf/
    /// </summary>
    public class EnumBindingSourceExtension : MarkupExtension
    {
        // ReSharper disable once InconsistentNaming
        private Type _enumType;
        public Type EnumType
        {
            get
            {
                return _enumType;
            }
            set
            {
                Contract.Assert(null != value);

                if (value != _enumType)
                {
                    var enumType = Nullable.GetUnderlyingType(value) ?? value;
                    Contract.Assert(enumType.IsEnum);

                    _enumType = value;
                }
            }
        }

        public EnumBindingSourceExtension()
        {
            // N/A
        }

        public EnumBindingSourceExtension(Type enumType)
        {
            Contract.Requires(null != enumType);

            EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            Contract.Assert(null != _enumType);

            var actualEnumType = Nullable.GetUnderlyingType(_enumType) ?? _enumType;
            var enumValues = Enum.GetValues(actualEnumType);

            if (actualEnumType == _enumType)
            {
                return enumValues;
            }

            var tempArray = Array.CreateInstance(actualEnumType, enumValues.Length + 1);
            enumValues.CopyTo(tempArray, 1);

            return tempArray;
        }
    }
}
