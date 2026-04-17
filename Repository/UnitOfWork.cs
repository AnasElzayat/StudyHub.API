using StudyHub.API.Data;
using StudyHub.API.Repository.IRepository;

namespace StudyHub.API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudyHubContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(StudyHubContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repositoryInstance = new Repository<T>(_context);
                _repositories.Add(typeof(T), repositoryInstance);
            }

            return (IRepository<T>)_repositories[typeof(T)];
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
