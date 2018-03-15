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
using Net.Appclusive.WPF.UI.Extensions;
using biz.dfch.CS.Testing.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Net.Appclusive.WPF.UI.Tests.Extensions
{
    [TestClass]
    public class EnumBindingSourceExtensionTest
    {
        [ExpectContractFailure(MessagePattern = "Precondition.+enumType")]
        [TestMethod]
        public void InstantiateEnumBindingSourceExtensionWithNullTypeThrowsContractException()
        {
            // Arrange

            // Act
            // ReSharper disable once ObjectCreationAsStatement
            new EnumBindingSourceExtension(null);

            // Assert
        }

        [ExpectContractFailure(MessagePattern = "Assertion.+value")]
        [TestMethod]
        public void AssignNullToEnumTypePropertyThrowsContractException()
        {
            // Arrange
            // ReSharper disable once UseObjectOrCollectionInitializer
            var sut = new EnumBindingSourceExtension();

            // Act
            sut.EnumType = null;

            // Assert
        }

        [ExpectContractFailure(MessagePattern = "Assertion.+IsEnum")]
        [TestMethod]
        public void AssignNonEnumTypeToEnumTypePropertyThrowsContractException()
        {
            // Arrange
            // ReSharper disable once UseObjectOrCollectionInitializer
            var sut = new EnumBindingSourceExtension();

            // Act
            sut.EnumType = typeof(ArgumentException);

            // Assert
        }

        [ExpectContractFailure(MessagePattern = "Assertion.+_enumType")]
        [TestMethod]
        public void InvokeProvideValueOnInstanceWithoutSpecifiedEnumTypeThrowsContractException()
        {
            // Arrange
            var sut = new EnumBindingSourceExtension();

            // Act
            // ReSharper disable once AssignNullToNotNullAttribute
            sut.ProvideValue(null);

            // Assert
        }

        [TestMethod]
        public void InvokeProvideValuesOnInstanceWithEnumTypeDefinedReturnsValuesOfSpecifiedEnumType()
        {
            // Arrange
            var sut = new EnumBindingSourceExtension(typeof(ArbitraryEnum));

            // Act
            // ReSharper disable once AssignNullToNotNullAttribute
            var result = sut.ProvideValue(null);

            // Assert
            Assert.IsNotNull(result);

            var array = result as ArbitraryEnum[];
            Assert.IsNotNull(array);
            Assert.AreEqual(3, array.Length);
        }
    }
}
