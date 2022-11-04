using Microsoft.Extensions.DependencyInjection;

using PL.Pages;

namespace PL
{
    public static class View
    {
        public static IServiceCollection SetPages(this IServiceCollection services)
        {
            services.AddSingleton<Page>();
            services.AddSingleton<BooksPage>();
            services.AddSingleton<ClientsPage>();
            services.AddSingleton<MainPage>();
            services.AddSingleton<Client>();

            return services;
        }
    }
}
