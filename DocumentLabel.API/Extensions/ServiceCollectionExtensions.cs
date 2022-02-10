using DocumentLabel.API.Mediator;
using DocumentLabel.API.Services;
using DocumentLabel.Domain;
using DocumentLabel.Domain.Dispatcher;
using DocumentLabel.Domain.Interfaces;
using DocumentLabel.Infrastructure;
using DocumentLabel.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DocumentLabel.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>))
                .AddScoped<IDocumentRequestRepository, DocumentRequestRepository>();
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services
            , IConfiguration configuration)
        {
            return services.AddDbContext<DataContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("DocumentLabelDbConnectionString")));
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services
           )
        {
            return services
                .AddScoped<DocumentRequestService>()
                .AddScoped<LookupService>()
                .AddScoped<UserService>();
        }
        public static IServiceCollection AddMediatrServices(this IServiceCollection services
          )
        {
           return services.AddMediatR(typeof(MediatrDomainEventDispatcher).GetTypeInfo().Assembly);
        }
        public static IServiceCollection AddDispatcherServices(this IServiceCollection services
           )
        {
            return services.AddScoped<IDomainEventDispatcher, MediatrDomainEventDispatcher>();
        }
    }
}
