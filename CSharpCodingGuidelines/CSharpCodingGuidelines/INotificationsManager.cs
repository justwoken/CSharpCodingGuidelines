namespace SoftServe.CSharpCodingGuidelines.WpfApp
{
    /// <summary>
    /// Ntofications Manager interface.
    /// </summary>
    public interface INotificationsManager
    {
        /// <summary>
        /// Notifies manager with the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Notify(string message);
    }
}