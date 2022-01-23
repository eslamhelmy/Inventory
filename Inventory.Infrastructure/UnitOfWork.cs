using Inventory.Domain.Base;
using Inventory.Domain.Interfaces;
using Inventory.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductContext _dbContext;

        public UnitOfWork(ProductContext dbContext)
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
