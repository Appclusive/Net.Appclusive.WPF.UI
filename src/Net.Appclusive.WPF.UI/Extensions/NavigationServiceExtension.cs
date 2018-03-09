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
using System.Windows.Navigation;

namespace Net.Appclusive.WPF.UI.Extensions
{
    public static class NavigationServiceExtension
    {
        private const string PAGES_DIRECTORY = "Pages/";
        private const string PAGE_SUFFIX = ".xaml";

        public static bool NavigateToPage(this NavigationService service, string pageName)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(pageName));

            var navigationUri = new Uri(string.Concat(PAGES_DIRECTORY, pageName, PAGE_SUFFIX), UriKind.Relative);

            return service.Navigate(navigationUri);
        }

        public static bool NavigateToPage(this NavigationService service, string pageName, object navigationState)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(pageName));
            Contract.Requires(null != navigationState);

            var navigationUri = new Uri(string.Concat(PAGES_DIRECTORY, pageName, PAGE_SUFFIX), UriKind.Relative);

            return service.Navigate(navigationUri, navigationState);
        }
    }
}
