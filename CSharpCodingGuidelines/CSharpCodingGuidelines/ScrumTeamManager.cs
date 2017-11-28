using System;
using System.Collections.Generic;
using System.Linq;
using Justwoken.CSharpCodingGuidelines.WpfApp.Models;
using Justwoken.CSharpCodingGuidelines.WpfApp.Properties;

namespace Justwoken.CSharpCodingGuidelines.WpfApp
{
    /// <summary>
    /// SCRUM team manager maintains collections of team members.
    /// </summary>
    public class ScrumTeamManager
    {
        private const int MAX_TEAM_MEMBERS_COUNT = 10;

        private readonly INotificationsManager notificationsManager;
        private readonly ITeamMemberValidator teamMemberValidator;

        private readonly Guid teamGuid = Guid.NewGuid();
        private readonly object locker = new object();

        private List<TeamMember> teamMembers;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrumTeamManager"/> class.
        /// </summary>
        /// <param name="notificationsManager">The notifications manager.</param>
        /// <param name="teamMemberValidator">The team member validator.</param>
        public ScrumTeamManager(INotificationsManager notificationsManager,
                                ITeamMemberValidator teamMemberValidator)
        {
            // TIP: use constructor for dependency injection to avoid Injection Parameters
            // TIP: use Initialize method or initial data provider to pass some initial data
            this.notificationsManager = notificationsManager;
            this.teamMemberValidator = teamMemberValidator;
        }

        // TIP: CSV is 3-char abbreviation - use it as a word.
        private string GenerateCsvString(int[] integers)
        {
            const string COMMA = ",";
            // TIP: use string.Join to create separated string
            // TIP: if 3 or less short-named parameters used - prefer to put on single line
            return string.Join(COMMA, integers);
        }

        /// <summary>
        /// Initializes Scrum Team Manager instance
        /// </summary>
        /// <param name="initialTeam">Initial team</param>
        public void Initialize(IEnumerable<TeamMember> initialTeam)
        {
            // TIP: prefer "x.Any(...)" over "x.Where(...).Any()"
            // TIP: prefer "!x.Any()" over  "x.Count() == 0"
            // TIP: prefer "result" or "!result" over "result == true" or "result == false"
            // TIP: short boolean conditions could be put on the same line
            if (initialTeam == null || !initialTeam.Any())
            {
                return;
            }

            teamMembers = new List<TeamMember>();

            // TIP: prefer "foreach" over using collection.ToList().ForEach(...)
            // TIP: prefer collection.Where(FilterMethod) over collection.Where(member => FilterMethod(member))
            foreach (TeamMember teamMember in initialTeam.Where(CheckTeamMemberNotAssigned))
            {
                AddTeamMember(teamMember);
            }

            // TIP: if you already have a list instantiated - ForEach is great
            // TIP: do not to add/delete list items inside ForEach
            teamMembers.ForEach(AssignTeamGuidToMember);
        }

        private bool CheckTeamMemberNotAssigned(TeamMember teamMember)
        {
            return teamMember.TeamGuid == Guid.Empty;
        }

        private void AssignTeamGuidToMember(TeamMember teamMember)
        {
            teamMember.TeamGuid = teamGuid;
        }

        /// <summary>
        /// Gets available team roles except SCRUM master
        /// </summary>
        /// <returns>Team roles</returns>
        public IEnumerable<TeamRole> GetAvailableTeamRoles()
        {
            return teamMembers?.Select(t => t.Role)
                              .Except(new[]
                                      {
                                          TeamRole.ScrumMaster
                                      })
                              .Distinct();
        }

        /// <summary>
        /// Gets the last name of the SCRUM master.
        /// </summary>
        /// <returns>SCRUM master's last name or empty string.</returns>
        public string GetScrumMasterLastName()
        {
            // TIP: var can be used to shorten code, especially if type is obvious
            var scrumMaster = teamMembers.FirstOrDefault(t => t.Role == TeamRole.ScrumMaster);
            return scrumMaster?.LastName ?? string.Empty;
        }

        /// <summary>
        /// Add new member into managed SCRUM team
        /// </summary>
        /// <param name="teamMember">Team member to add</param>
        public void AddTeamMember(TeamMember teamMember)
        {
            // TIP: use concurrent collections instead of locking simple collection manipulation
            lock (locker)
            {
                // TIP: try flatten methods and not to use nested "if" blocks
                if (!CheckMemberValidAndCanBeAdded(teamMember))
                {
                    return;
                }

                if (CheckIfAddingSecondScrumMaster(teamMember))
                {
                    notificationsManager.Notify(Resources.ScrumTeamManager_TeamAlreadyHasScrumMaster);
                }
                else
                {
                    teamMembers.Add(teamMember);
                    NotifyTeamMemberAdded(teamMember);
                }
            }
        }

        // TIP: prefer grouping methods by functionality
        // TIP: prefer using regions for functionality groups, not private/public groups
        private bool CheckMemberValidAndCanBeAdded(TeamMember teamMember)
        {
            return teamMembers.Count < MAX_TEAM_MEMBERS_COUNT
                   && teamMemberValidator.Validate(teamMember);
        }

        private bool CheckIfAddingSecondScrumMaster(TeamMember teamMember)
        {
            return teamMember.Role == TeamRole.ScrumMaster
                   && teamMembers.Any(t => t.Role == TeamRole.ScrumMaster);
        }

        private void NotifyTeamMemberAdded(TeamMember teamMember)
        {
            string notication = teamMember.Role == TeamRole.UIDesigner
                                          ? Resources.ScrumTeamManager_UIDesignerAdded
                                          : Resources.ScrumTeamManager_TeamMemberAdded;

            // TIP: prefer using string interpolation if possible
            string notificationMessage = $"{notication}: {teamMember.FirstName} {teamMember.LastName}";

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

    }
}