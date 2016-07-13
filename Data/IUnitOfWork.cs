namespace aspnet_core.models
{
    /// <summary>
    /// IUnitOfWork
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Complete unit of work
        /// </summary>
        /// <returns></returns>
        System.Threading.Tasks.Task Complete();
    }
}