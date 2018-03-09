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

using System.Globalization;
using Net.Appclusive.WPF.UI.Converters;
using Net.Appclusive.WPF.UI.Extensions;
using biz.dfch.CS.Testing.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Net.Appclusive.WPF.UI.Tests.Converters
{
    [TestClass]
    public class EnumTranslationConverterTest
    {
        [ExpectContractFailure(MessagePattern = "Precondition.+type")]
        [TestMethod]
        public void InstantiateEnumTranslationConverterWithNullTypeThrowsContractException()
        {
            // Arrange

            // Act
            // ReSharper disable once ObjectCreationAsStatement
            new EnumTranslationCoverter(null);

            // Assert
        }

        [ExpectContractFailure(MessagePattern = "Assertion.+context")]
        [TestMethod]
        public void ConvertToWithNullContextThrowsContractException()
        {
            // Arrange
            var sut = new EnumTranslationCoverter(typeof(ArbitraryEnum));

            // Act
            sut.ConvertTo(null, CultureInfo.CurrentCulture, ArbitraryEnum.Value1, typeof(string));

            // Assert
        }

        [ExpectContractFailure(MessagePattern = "Assertion.+culture")]
        [TestMethod]
        public void ConvertToWithNullCultureInfoThrowsContractException()
        {
            // Arrange
            var sut = new EnumTranslationCoverter(typeof(ArbitraryEnum));

            // Act
            sut.ConvertTo(new DummyDescriptorContext(), null, ArbitraryEnum.Value1, typeof(string));

            // Assert
        }

        [ExpectContractFailure(MessagePattern = "Assertion.+destinationType")]
        [TestMethod]
        public void ConvertToWithNullDestinationTypeThrowsContractException()
        {
            // Arrange
            var sut = new EnumTranslationCoverter(typeof(ArbitraryEnum));

            // Act
            // ReSharper disable once AssignNullToNotNullAttribute
            sut.ConvertTo(new DummyDescriptorContext(), CultureInfo.CurrentCulture, ArbitraryEnum.Value1, null);

            // Assert
        }

        [TestMethod]
        public void ConvertToWithNullValueReturnsEmptyString()
        {
            // Arrange
            var sut = new EnumTranslationCoverter(typeof(ArbitraryEnum));

            // Act
            var result = sut.ConvertTo(new DummyDescriptorContext(), CultureInfo.CurrentCulture, null, typeof(string));

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void ConvertToWithValidArgumentsForEnumWithResourceNameAttributePointingToExistingResourceEntryReturnsResourceEntryValue()
        {
            // Arrange
            var sut = new EnumTranslationCoverter(typeof(ArbitraryEnum));

            // Act
            var result = sut.ConvertTo(new DummyDescriptorContext(), CultureInfo.CurrentCulture, ArbitraryEnum.Value1, typeof(string));

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(string.Empty, result);
            Assert.AreEqual("ArbitraryValue1", result);
        }

        [TestMethod]
        public void ConvertToWithValidArgumentsForEnumWithoutResourceNameAttributeReturnsValueOfEnum()
        {
            // Arrange
            var sut = new EnumTranslationCoverter(typeof(ArbitraryEnum));

            // Act
            var result = sut.ConvertTo(new DummyDescriptorContext(), CultureInfo.CurrentCulture, ArbitraryEnum.Value3, typeof(string));

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(string.Empty, result);
            Assert.AreEqual(ArbitraryEnum.Value3.ToString(), result);
        }

        [TestMethod]
        public void ConvertToWithValidArgumentsForEnumWithResourceNameAttributePointingToNonExistingResourceEntryReturnsMissingResourceEntryText()
        {
            // Arrange
            var sut = new EnumTranslationCoverter(typeof(ArbitraryEnum));

            // Act
            var result = sut.ConvertTo(new DummyDescriptorContext(), CultureInfo.CurrentCulture, ArbitraryEnum.Value2, typeof(string));

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(string.Empty, result);
            Assert.AreEqual(EnumTranslationCoverter.MISSING_RESOURCE_ENTRY, result);
        }
    }
}
