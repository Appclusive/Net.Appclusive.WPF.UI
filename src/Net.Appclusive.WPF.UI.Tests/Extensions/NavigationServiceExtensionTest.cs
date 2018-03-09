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
using System.Windows.Navigation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using biz.dfch.CS.Testing.Attributes;
using Net.Appclusive.WPF.UI.Extensions;
using Net.Appclusive.WPF.UI.Pages;
using Telerik.JustMock;

namespace Net.Appclusive.WPF.UI.Tests.Extensions
{
    [TestClass]
    public class NavigationServiceExtensionTest
    {
        private const string HOME_URI = "Pages/Home.xaml";

        [ExpectContractFailure(MessagePattern = "Precondition.+pageName")]
        [TestMethod]
        public void NavigateToPageWithNullPageNameThrowsContractException()
        {
            // Arrange
            var navigationService = Mock.Create<NavigationService>();

            // Act
            // ReSharper disable once InvokeAsExtensionMethod
            NavigationServiceExtension.NavigateToPage(navigationService, null);

            // Assert
        }

        [ExpectContractFailure(MessagePattern = "Precondition.+pageName")]
        [TestMethod]
        public void NavigateToPageWithEmptyPageNameThrowsContractException()
        {
            // Arrange
            var navigationService = Mock.Create<NavigationService>();

            // Act
            // ReSharper disable once InvokeAsExtensionMethod
            NavigationServiceExtension.NavigateToPage(navigationService, string.Empty);

            // Assert
        }

        [TestMethod]
        public void NavigateToPageWithValidPageNameCreatesPageUriCallsNavigateOnNavigationServiceAndReturnsNavigationResult()
        {
            // Arrange
            var expectedUri = HOME_URI;
            var navigationService = Mock.Create<NavigationService>();

            Mock.Arrange(() => navigationService.Navigate(Arg.Matches<Uri>(uri => uri.ToString() == expectedUri)))
                .Returns(true)
                .OccursOnce();

            // Act
            // ReSharper disable once InvokeAsExtensionMethod
            var navigationResult = NavigationServiceExtension.NavigateToPage(navigationService, nameof(Home));

            // Assert
            Assert.IsTrue(navigationResult);

            Mock.Assert(navigationService);
        }

        [ExpectContractFailure(MessagePattern = "Precondition.+pageName")]
        [TestMethod]
        public void NavigateToPageWithNullPageNameAndValidNavigationStateThrowsContractException()
        {
            // Arrange
            var navigationService = Mock.Create<NavigationService>();

            // Act
            // ReSharper disable once InvokeAsExtensionMethod
            NavigationServiceExtension.NavigateToPage(navigationService, null, new object());

            // Assert
        }

        [ExpectContractFailure(MessagePattern = "Precondition.+pageName")]
        [TestMethod]
        public void NavigateToPageWithEmptyPageNameAndValidNavigationStateThrowsContractException()
        {
            // Arrange
            var navigationService = Mock.Create<NavigationService>();

            // Act
            // ReSharper disable once InvokeAsExtensionMethod
            NavigationServiceExtension.NavigateToPage(navigationService, string.Empty, new object());

            // Assert
        }

        [ExpectContractFailure(MessagePattern = "Precondition.+navigationState")]
        [TestMethod]
        public void NavigateToPageWithNullNavigationStateThrowsContractException()
        {
            // Arrange
            var navigationService = Mock.Create<NavigationService>();

            // Act
            // ReSharper disable once InvokeAsExtensionMethod
            NavigationServiceExtension.NavigateToPage(navigationService, HOME_URI, null);

            // Assert
        }

        [TestMethod]
        public void NavigateToPageWithValidPageNameAndNonNullNavigationStateCreatesPageUriCallsNavigateOnNavigationServiceAndReturnsNavigationResult()
        {
            // Arrange
            var expectedUri = HOME_URI;
            var navigationService = Mock.Create<NavigationService>();

            Mock.Arrange(() => navigationService.Navigate(Arg.Matches<Uri>(uri => uri.ToString() == expectedUri), Arg.IsAny<object>()))
                .Returns(true)
                .OccursOnce();

            // Act
            // ReSharper disable once InvokeAsExtensionMethod
            var navigationResult = NavigationServiceExtension.NavigateToPage(navigationService, nameof(Home), new object());

            // Assert
            Assert.IsTrue(navigationResult);

            Mock.Assert(navigationService);
        }
    }
}
