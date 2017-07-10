using Justwoken.CSharpCodingGuidelines.WpfApp.Models;

namespace Justwoken.CSharpCodingGuidelines.WpfApp
{
    /// <summary>
    /// Team member validator class.
    /// </summary>
    /// <seealso cref="Justwoken.CSharpCodingGuidelines.WpfApp.ITeamMemberValidator" />
    public class TeamMemberValidator : ITeamMemberValidator
    {
        /// <summary>
        /// Validates the specified team member.
        /// </summary>
        /// <param name="teamMember">The team member.</param>
        /// <returns>
        /// Whether team member valid or not.
        /// </returns>
        public bool Validate(TeamMember teamMember)
        {
            // NOTE: Do not compare to string.Empty or "", use special methods
            return teamMember != null
                   && string.IsNullOrWhiteSpace(teamMember.FirstName)
                   && string.IsNullOrWhiteSpace(teamMember.LastName);
        }
    }
}
