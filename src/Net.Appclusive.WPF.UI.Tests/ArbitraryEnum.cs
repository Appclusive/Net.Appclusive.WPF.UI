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

using Net.Appclusive.WPF.UI.Attributes;
using Net.Appclusive.WPF.UI.Converters;
using System.ComponentModel;

namespace Net.Appclusive.WPF.UI.Tests
{
    [TypeConverter(typeof(EnumTranslationCoverter))]
    public enum ArbitraryEnum
    {
        [ResourceName("ArbitraryEnum_Value1")]
        Value1,
        [ResourceName("ArbitraryEnum_Value2")]
        Value2,
        Value3
    }
}
