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

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Net.Appclusive.WPF.UI.ViewModels
{
    /// <summary>
    /// All ViewModel classes that are bound to by the view should implement 
    /// INotifyPropertyChanged (even if the values don't change from the ViewModel) 
    /// as there is a known memory leak that may occur if they don’t.
    /// 
    /// see https://support.microsoft.com/en-us/help/938416/a-memory-leak-may-occur-when-you-use-data-binding-in-windows-presentation-foundation
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        protected static readonly App CurrentApp = Application.Current as App;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(propertyName));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// For details concerning validation code see 
        /// http://www.c-sharpcorner.com/UploadFile/20c06b/screen-validation-with-data-annotations-in-wpf/
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns>null, if there aren't any validation erros, otherwise validation error message will be returned</returns>
        public virtual string this[string columnName]
        {
            get
            {
                var validationResults = new List<ValidationResult>();

                var property = GetType().GetProperty(columnName);
                Contract.Assert(null != property);

                var validationContext = new ValidationContext(this)
                {
                    MemberName = columnName
                };

                var isValid = Validator.TryValidateProperty(property.GetValue(this), validationContext, validationResults);
                if (isValid)
                {
                    return null;
                }

                return validationResults.First().ErrorMessage;
            }
        }

        public virtual string Error
        {
            get
            {
                var propertyInfos = GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);

                foreach (var propertyInfo in propertyInfos)
                {
                    var errorMsg = this[propertyInfo.Name];
                    if (null != errorMsg)
                    {
                        return errorMsg;
                    }
                }

                return null;
            }
        }
    }
}
