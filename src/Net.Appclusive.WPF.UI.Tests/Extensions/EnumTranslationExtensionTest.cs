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

using System.ComponentModel;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Appclusive.WPF.UI.Converters;
using Net.Appclusive.WPF.UI.Extensions;
using Telerik.JustMock;

namespace Net.Appclusive.WPF.UI.Tests.Extensions
{
    [TestClass]
    public class EnumTranslationExtensionTest
    {
        [TestMethod]
        public void GetTranslatedValueWithEnumCallsEnumTranslationConverter()
        {
            // Arrange
            var expectedValue = "arbitrary";

            var enumTranslationConverter = Mock.Create<EnumTranslationCoverter>();

            Mock.Arrange(() => new EnumTranslationCoverter(typeof(ArbitraryEnum)))
                .Returns(enumTranslationConverter)
                .OccursOnce();

            Mock.Arrange(() => enumTranslationConverter.ConvertTo(Arg.IsAny<ITypeDescriptorContext>(), CultureInfo.CurrentCulture, ArbitraryEnum.Value1, typeof(string)))
                .Returns(expectedValue)
                .OccursOnce();

            // Act
            var result = ArbitraryEnum.Value1.GetTranslatedValue();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedValue, result);

            Mock.Assert(() => new EnumTranslationCoverter(typeof(ArbitraryEnum)));
            Mock.Assert(enumTranslationConverter);
        }
    }
}
