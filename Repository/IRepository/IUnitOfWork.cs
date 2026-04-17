namespace StudyHub.API.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        Task<int> SaveAsync();
    }
}
