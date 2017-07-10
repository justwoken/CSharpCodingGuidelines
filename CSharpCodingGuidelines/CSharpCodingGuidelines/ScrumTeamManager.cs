using Justwoken.CSharpCodingGuidelines.WpfApp.Models;
using Justwoken.CSharpCodingGuidelines.WpfApp.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Justwoken.CSharpCodingGuidelines.WpfApp
{
    /// <summary>
    /// SCRUM team manager.
    /// </summary>
    public class ScrumTeamManager
    {
        private const int MAX_TEAM_MEMBERS_COUNT = 10;

        private List<TeamMember> teamMembers;

        private readonly INotificationsManager notificationsManager;
        private readonly ITeamMemberValidator teamMemberValidator;

        private readonly Guid teamGuid = Guid.NewGuid();
        private readonly object locker = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrumTeamManager"/> class.
        /// </summary>
        /// <param name="notificationsManager">The notifications manager.</param>
        /// <param name="teamMemberValidator">The team member validator.</param>
        public ScrumTeamManager(INotificationsManager notificationsManager,
                                ITeamMemberValidator teamMemberValidator)
        {
            // use constructor for dependency injection and Initialize method
            // to pass some initial data
            this.notificationsManager = notificationsManager;
            this.teamMemberValidator = teamMemberValidator;
        }

        private bool CheckMemberValidAndCanBeAdded(TeamMember teamMember) =>
            teamMembers.Count < MAX_TEAM_MEMBERS_COUNT
            && teamMemberValidator.Validate(teamMember);

        private bool CheckIfAddingSecondScrumMaster(TeamMember teamMember)
        {
            return teamMember.Role == TeamRole.ScrumMaster
                   && teamMembers.Any(t => t.Role == TeamRole.ScrumMaster);
        }

        private bool CheckTeamMemberNotAssigned(TeamMember teamMember) => teamMember.TeamGuid == Guid.Empty;

        private void AssignTeamGuidToMember(TeamMember teamMember) => teamMember.TeamGuid = teamGuid;

        private void NotifyTeamMemberAdded(TeamMember teamMember)
        {
            string noticationFormat = teamMember.Role == TeamRole.UIDesigner
                                      ? Resources.ScrumTeamManager_UIDesignerAddedFormat
                                      : Resources.ScrumTeamManager_TeamMemberAddedFormat;

            string notificationMessage = string.Format(noticationFormat,
                                                       teamMember.FirstName,
                                                       teamMember.LastName);

            try
            {
                notificationsManager.Notify(notificationMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        // NOTE: CSV is 3-char abbreviation - use it as a word.
        private string GenerateCsvString(int[] integers)
        {
            // NOTE: instead of string builder, or string concatenation
            // to create symbol-separated string, use string.Join
            const string COMMA = ",";
            return string.Join(COMMA, integers);
        }

        /// <summary>
        /// Initializes Scrum Team Manager instance
        /// </summary>
        /// <param name="initialTeam">Initial team</param>
        public void Initialize(IEnumerable<TeamMember> initialTeam)
        {
            // NOTE: DO USE "!x.Any(x => x > 0)" 
            // don't use "!x.Where(x => x > 0).Any()"
            // don't use "x.Any() == false"
            // don't use "x.Count() == 0"
            if (initialTeam == null || !initialTeam.Any())
            {
                return;
            }

            teamMembers = new List<TeamMember>();

            // if you want to iterate collection prefer "foreach" over using
            // .ToList().ForEach() methods
            foreach (TeamMember teamMember in initialTeam.Where(CheckTeamMemberNotAssigned))
            {
                AddTeamMember(teamMember);
            }

            // if you already have a list instantiated - ForEach is great
            // Though still remember not to add/delete list items
            teamMembers.ForEach(AssignTeamGuidToMember);
        }

        /// <summary>
        /// Gets available team roles except SCRUM master
        /// </summary>
        /// <returns>Team roles</returns>
        public IEnumerable<TeamRole> GetAvailableTeamRoles()
        {
            return teamMembers?.Select(t => t.Role)
                              .Except(new[] { TeamRole.ScrumMaster })
                              .Distinct();
        }

        /// <summary>
        /// Gets the last name of the SCRUM master.
        /// </summary>
        /// <returns>SCRUM master's last name or empty string.</returns>
        public string GetScrumMasterLastName()
        {
            TeamMember scrumMaster = teamMembers.FirstOrDefault(t => t.Role == TeamRole.ScrumMaster);
            return scrumMaster?.LastName ?? string.Empty;
        }

        /// <summary>
        /// Add new member into managed SCRUM team
        /// </summary>
        /// <param name="teamMember">Team member to add</param>
        public void AddTeamMember(TeamMember teamMember)
        {
            lock (locker)
            {
                // try flatten methods and not to use nested "if" blocks
                if (!CheckMemberValidAndCanBeAdded(teamMember))
                {
                    return;
                }

                if (CheckIfAddingSecondScrumMaster(teamMember))
                {
                    notificationsManager.Notify(Resources.ScrumTeamManager_TeamAlreadyHasScrumMaster);
                    return;
                }

                teamMembers.Add(teamMember);

                NotifyTeamMemberAdded(teamMember);
            }
        }
    }
}
