namespace Justwoken.CSharpCodingGuidelines.WpfApp.Models
{
    /// <summary>
    /// Team roles enumeration.
    /// </summary>
    public enum TeamRole
    {
        // TIP: prefer default enumeration values over changing them (exception: bit flags and part of public API)
        ScrumMaster,
        Developer,
        Tester,
        UIDesigner,
        Analyst,
        Architect
    }
}