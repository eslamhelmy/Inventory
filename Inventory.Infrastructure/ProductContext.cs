using Inventory.Domain;
using Inventory.Domain.Base;
using Inventory.Domain.Dispatcher;
using Inventory.Infrastructure.ModelBuilderExtensions;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Infrastructure
{
    public class ProductContext: DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;
        public ProductContext(DbContextOptions<ProductContext> options, IDomainEventDispatcher dispatcher) : base(options)
        {
            _dispatcher = dispatcher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var domainEntities = ChangeTracker.Entries<BaseEntity>();
            foreach (var domainEntity in domainEntities)
            {
               var events = domainEntity.Entity.Events;
                foreach (var item in events)
                {
                   await _dispatcher.Dispatch(item);
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
