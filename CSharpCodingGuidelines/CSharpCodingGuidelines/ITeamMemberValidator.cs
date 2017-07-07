using Justwoken.CSharpCodingGuidelines.WpfApp.Models;

namespace Justwoken.CSharpCodingGuidelines.WpfApp
{
    /// <summary>
    /// Team member validator interface.
    /// </summary>
    public interface ITeamMemberValidator
    {
        /// <summary>
        /// Validates the specified team member.
        /// </summary>
        /// <param name="teamMember">The team member.</param>
        /// <returns>Whether team member valid or not.</returns>
        bool Validate(TeamMember teamMember);
    }
}