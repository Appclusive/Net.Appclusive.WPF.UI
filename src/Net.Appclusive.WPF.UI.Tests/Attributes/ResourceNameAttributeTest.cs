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

using biz.dfch.CS.Testing.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Appclusive.WPF.UI.Attributes;

namespace Net.Appclusive.WPF.UI.Tests.Attributes
{
    [TestClass]
    public class ResourceNameAttributeTest
    {
        [ExpectContractFailure(MessagePattern = "Precondition.+name")]
        [TestMethod]
        public void InstantiateResourceKeyAttributeWithNullNameThrowsContractException()
        {
            // Arrange

            // Act
            // ReSharper disable once ObjectCreationAsStatement
            new ResourceNameAttribute(null);

            // Assert
        }

        [ExpectContractFailure(MessagePattern = "Precondition.+name")]
        [TestMethod]
        public void InstantiateResourceKeyAttributeWithEmptyNameThrowsContractException()
        {
            // Arrange

            // Act
            // ReSharper disable once ObjectCreationAsStatement
            new ResourceNameAttribute(string.Empty);

            // Assert
        }
    }
}
