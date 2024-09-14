using GoodReads.Core.Repositories;
using GoodReads.Core.Services;
using GoodReads.Core.UnitOfWork;
using GoodReads.Infrastructure.Repositories;
using GoodReads.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
            services
                .AddRepositories()
                .AddServices()
                .AddUnitOfWork();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection service) {
            service.AddScoped<IBookRepository, BookRepository>();
            service.AddScoped<IUserRepository, UserRepository>();

            return service;
        }

        private static IServiceCollection AddServices(this IServiceCollection service) { 
            service.AddScoped<IBookService, BookService>();

            return service;
        }

        private static IServiceCollection AddUnitOfWork(this IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            return service;
        }
    }
}
