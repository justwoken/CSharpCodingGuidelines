namespace SoftServe.CSharpCodingGuidelines.WpfApp.Models
{
    /// <summary>
    /// Team roles enumeration.
    /// </summary>
    public enum TeamRole
    {
        // NOTE: avoid changing default values (exception: bit flags)
        ScrumMaster,
        Developer,
        Tester,
        // NOTE: UI abbreviation
        UIDesigner,
        Analyst,
        Architect
    }
}