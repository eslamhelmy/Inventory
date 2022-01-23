﻿using Inventory.API.Mediator;
using Inventory.API.Services;
using Inventory.Domain;
using Inventory.Domain.Dispatcher;
using Inventory.Domain.Interfaces;
using Inventory.Infrastructure;
using Inventory.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Inventory.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>))
                .AddScoped<IProductRepository, ProductRepository>();
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services
            , IConfiguration configuration)
        {
            return services.AddDbContext<ProductContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("ProductDbConnectionString")));
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services
           )
        {
            return services
                .AddScoped<ProductService>();
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
