﻿using Microsoft.Practices.Unity;
using System.Windows;

namespace SoftServe.CSharpCodingGuidelines.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs" /> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = new UnityContainer();
            container.RegisterType<ITeamMemberValidator, TeamMemberValidator>(new ContainerControlledLifetimeManager());

            base.OnStartup(e);
        }
    }
}
