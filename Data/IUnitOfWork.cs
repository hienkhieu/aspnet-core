namespace aspnet_core.models
{
    /// <summary>
    /// IUnitOfWork
    /// </summary>
    interface IUnitOfWork
    {
        System.Threading.Tasks.Task Complete();
    }
}