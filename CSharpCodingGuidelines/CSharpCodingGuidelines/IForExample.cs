namespace SoftServe.CSharpCodingGuidelines.WpfApp
{
    /// <summary>
    /// Example interface.
    /// </summary>
    public interface IForExample<T, TResult>
    {
        /// <summary>
        /// Executes the generic action with generic result.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>Generic result.</returns>
        TResult ExecuteGenericActionWithGenericResult(T target);
    }
}