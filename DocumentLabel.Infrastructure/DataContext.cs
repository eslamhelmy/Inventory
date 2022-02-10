
using DocumentLabel.Domain;
using DocumentLabel.Domain.Base;
using DocumentLabel.Domain.Dispatcher;
using DocumentLabel.Infrastructure.ModelBuilderExtensions;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentLabel.Infrastructure
{
    public class DataContext: DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;
        public DataContext(DbContextOptions<DataContext> options, IDomainEventDispatcher dispatcher) : base(options)
        {
            _dispatcher = dispatcher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentRequestTag>()
                        .HasOne(c => c.Tag)
                        .WithMany()
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Seed();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var domainEntities = ChangeTracker.Entries<BaseEntity>();
            foreach (var domainEntity in domainEntities)
            {
               var events = domainEntity.Entity.Events;
                if (events != null)
                {
                    foreach (var item in events)
                    {
                        await _dispatcher.Dispatch(item);
                    }

                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<DocumentRequest> DocumentRequests { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
