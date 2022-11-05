using Microsoft.Extensions.DependencyInjection;

using BAL.Services.Abstracts;
using BAL.Services;

namespace BAL
{
    public static class BllDependencies
    {
        public static IServiceCollection SetBllDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAuthorsService, AuthorsService>();
            services.AddScoped<IBooksService, BooksService>();
            services.AddScoped<IClientsService, ClientsService>();

            return services;
        }
    }
}