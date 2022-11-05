using Microsoft.Extensions.DependencyInjection;

using PL.Controllers;

namespace PL
{
    public static class PlDependencies
    {
        public static IServiceCollection SetPlDependencies(this IServiceCollection services)
        {
            services.AddSingleton<BooksController>();
            services.AddSingleton<ClientsController>();
            services.AddSingleton<MainController>();
            services.AddSingleton<Frontend>();

            return services;
        }
    }
}
