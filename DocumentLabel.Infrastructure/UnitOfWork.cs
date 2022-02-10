
using DocumentLabel.Domain.Base;
using DocumentLabel.Domain.Interfaces;
using DocumentLabel.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace DocumentLabel.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;

        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity
        {
            return new RepositoryBase<T>(_dbContext);
        }

        public Task<int> SaveChangesAsync()
        {   
            return _dbContext.SaveChangesAsync();
        }
    }
}
