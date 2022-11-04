using Microsoft.Extensions.DependencyInjection;

using BAL.Services.Abstracts;
using BAL.Services;

namespace BAL
{
    public static class Logic
    {
        public static IServiceCollection SetServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorsService<int>, AuthorsService>();
            services.AddScoped<IBooksService<int>, BooksService>();
            services.AddScoped<IClientsService<int>, ClientsService>();

            return services;
        }
    }
}