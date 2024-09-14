using FluentValidation;
using GoodReads.Application.Commands.Book.AddBook;
using Microsoft.Extensions.DependencyInjection;

namespace GoodReads.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddMediator()
                .AddValidation();
            return services;
        }

        private static IServiceCollection AddMediator(this IServiceCollection service) {
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddBookCommand).Assembly));
            return service;
        }

        private static IServiceCollection AddValidation(this IServiceCollection service) { 
            service.AddValidatorsFromAssemblyContaining<AddBookCommandValidator>();
            return service;
        }
    }
}
