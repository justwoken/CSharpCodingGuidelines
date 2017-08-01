using System;

namespace Justwoken.CSharpCodingGuidelines.WpfApp.Models
{
    /// <summary>
    /// Represents team member.
    /// </summary>
    /// <seealso cref="Justwoken.CSharpCodingGuidelines.WpfApp.Models.Employee"/>
    public class TeamMember : Employee
    {
        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        public TeamRole Role { get; set; }

        /// <summary>
        /// Gets or sets the team unique identifier.
        /// </summary>
        /// <remarks>
        /// NOTE: GUID abbreviation
        /// </remarks>
        public Guid TeamGuid { get; set; }
    }
}