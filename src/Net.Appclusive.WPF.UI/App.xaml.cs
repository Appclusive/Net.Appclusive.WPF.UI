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
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using biz.dfch.CS.Commons.Diagnostics;
using Net.Appclusive.WPF.UI.Constants;
using Net.Appclusive.WPF.UI.Security;
using TraceSource = biz.dfch.CS.Commons.Diagnostics.TraceSource;

namespace Net.Appclusive.WPF.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal NavigationService Navigator { get; set; }

        private readonly TraceSource traceSource = Logger.Get(Logging.TraceSourceName.APPCLUSIVE_WPF_UI);

        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            traceSource.TraceEvent(TraceEventType.Information, (int)Logging.EventId.Start, Message.App_OnStartup__Initialise_START);

            var appConfigSection = ConfigurationManager.GetSection(ApplicationConfigurationSection.SECTION_NAME) as ApplicationConfigurationSection;
            Contract.Assert(null != appConfigSection);

            traceSource.TraceEvent(TraceEventType.Information, (int)Logging.EventId.Default, Message.App_OnStartup__Initialise_Configuration);
            traceSource.TraceEvent(TraceEventType.Information, (int)Logging.EventId.Stop, Message.App_OnStartup__Initialise_SUCCEEDED);
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            if (null != exception)
            {
                traceSource.TraceException(exception, Message.App_CurrentDomain_UnhandledException__UnhandledExceptionOccurred);
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            traceSource.TraceEvent(TraceEventType.Information, (int)Logging.EventId.Start, Message.App_OnExit__START);

            base.OnExit(e);

            traceSource.TraceEvent(TraceEventType.Information, (int)Logging.EventId.Stop, Message.App_OnExit__SUCCEEDED);
        }

        protected override void OnNavigated(NavigationEventArgs e)
        {
            var page = e.Content as Page;

            if (null != page)
            {
                Navigator = page.NavigationService;
            }

            Navigator?.RemoveBackEntry();
        }
    }
}
