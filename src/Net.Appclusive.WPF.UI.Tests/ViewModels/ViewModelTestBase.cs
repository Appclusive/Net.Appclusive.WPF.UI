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

using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace Net.Appclusive.WPF.UI.Tests.ViewModels
{
    [TestClass]
    public class ViewModelTestBase
    {
        protected static App App;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            App = Mock.Create<App>(Behavior.CallOriginal);

            Mock.SetupStatic(typeof(Application));
            Mock.Arrange(() => Application.Current)
                .Returns(App);
        }
    }
}
