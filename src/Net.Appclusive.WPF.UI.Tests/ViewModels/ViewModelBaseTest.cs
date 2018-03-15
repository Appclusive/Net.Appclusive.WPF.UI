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

using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using biz.dfch.CS.Testing.Attributes;
using Net.Appclusive.WPF.UI.ViewModels;

namespace Net.Appclusive.WPF.UI.Tests.ViewModels
{
    [TestClass]
    public class ViewModelBaseTest
    {
        [ExpectContractFailure(MessagePattern = "Precondition.+propertyName")]
        [TestMethod]
        public void RaisePropertyChangedEventWithNullPropertyNameThrowsContractException()
        {
            // Arrange
            var sut = new ArbitraryViewModel();

            // Act
            sut.RaisePropertyChangedEvent();

            // Assert
        }

        [ExpectContractFailure(MessagePattern = "Assertion.+property")]
        [TestMethod]
        public void AccessingNonExistingColumnNameThroughIndexThrowsContractException()
        {
            // Arrange
            var sut = new ArbitraryViewModel();

            // Act
            // ReSharper disable once UnusedVariable
            var result = sut["arbitrary"];

            // Assert
        }

        [TestMethod]
        public void AccessingPropertyWithInvalidValueThroughIndexReturnsErrorMessage()
        {
            // Arrange
            var sut = new ArbitraryViewModel();

            // Act
            var result = sut[nameof(ArbitraryViewModel.Arbitrary)];

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains(nameof(ArbitraryViewModel.Arbitrary)));
        }

        [TestMethod]
        public void AccessingPropertyWithValidValueThroughIndexReturnsNull()
        {
            // Arrange
            var sut = new ArbitraryViewModel();

            // Act
            var result = sut[nameof(ArbitraryViewModel.Arbitrary2)];

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ErrorPropertyOfValidViewModelReturnsNull()
        {
            // Arrange
            var sut = new ArbitraryViewModel
            {
                Arbitrary = nameof(ArbitraryViewModel.Arbitrary)
            };

            // Act
            var result = sut.Error;

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ErrorPropertyOfInvalidViewModelReturnsErrorMessage()
        {
            // Arrange
            var sut = new ArbitraryViewModel();

            // Act
            var result = sut.Error;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains(nameof(ArbitraryViewModel.Arbitrary)));
        }
    }

    public class ArbitraryViewModel : ViewModelBase
    {
        public void RaisePropertyChangedEvent()
        {
            RaisePropertyChangedEvent(null);
        }

        [Required]
        public string Arbitrary { get; set; }

        [Required]
        public string Arbitrary2 { get; set; } = nameof(Arbitrary2);
    }
}
