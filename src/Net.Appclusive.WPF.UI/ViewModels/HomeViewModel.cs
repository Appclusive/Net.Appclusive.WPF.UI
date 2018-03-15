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

using Net.Appclusive.WPF.UI.Constants;
using System.ComponentModel.DataAnnotations;

namespace Net.Appclusive.WPF.UI.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        #region Properties

        private string domain = CurrentApp.DefaultDomain;

        [Required]
        [MaxLength(Validation.MAX_LENGTH_32)]
        public string Domain
        {
            get { return domain; }
            set
            {
                domain = value;
                RaisePropertyChangedEvent(nameof(Domain));
            }
        }

        private string username;

        [Required]
        [MaxLength(Validation.MAX_LENGTH_32)]
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                RaisePropertyChangedEvent(nameof(Username));
            }
        }

        private string password;

        [Required]
        [MaxLength(Validation.MAX_LENGTH_32)]
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChangedEvent(nameof(Password));
            }
        }

        #endregion Properties
    }
}
