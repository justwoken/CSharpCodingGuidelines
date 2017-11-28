using Justwoken.CSharpCodingGuidelines.WpfApp.Interfaces;
using Justwoken.CSharpCodingGuidelines.WpfApp.Logic;
using Microsoft.Practices.Unity;

namespace Justwoken.CSharpCodingGuidelines.WpfApp
{
    /// <summary>
    /// Configures Unity container in a separate extension.
    /// </summary>
    /// <seealso cref="Microsoft.Practices.Unity.UnityContainerExtension" />
    public class MainModuleContainerConfiguration : UnityContainerExtension
    {
        /// <summary>
        /// Initial the container with this extension's functionality.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        /// <remarks>
        /// When overridden in a derived class, this method will modify the given
        /// <see cref="T:Microsoft.Practices.Unity.ExtensionContext" /> by adding strategies, policies, etc. to
        /// install it's functions into the container.
        /// </remarks>
        protected override void Initialize()
        {
            Container.RegisterType<ITeamMemberValidator, TeamMemberValidator>(new ContainerControlledLifetimeManager());
        }
    }
}
