﻿using GoodReads.Core.Repositories;
using GoodReads.Core.Services;
using GoodReads.Core.UnitOfWork;
using GoodReads.Infrastructure.Persistence;
using GoodReads.Infrastructure.Persistence.Repositories;
using GoodReads.Infrastructure.Persistence.UnitOfWork;
using GoodReads.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            services
                .AddDbContext(configuration)
                .AddRepositories()
                .AddServices()
                .AddUnitOfWork();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection service) {
            service.AddScoped<IBookRepository, BookRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IReviewRepository, ReviewRepository>();

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

        private static IServiceCollection AddDbContext(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbContextCs");
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            service.AddDbContext<GoodReadsContext>(options => options.UseMySql(connectionString, serverVersion));

            return service;
        }

    }
}
