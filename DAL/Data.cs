using Microsoft.Extensions.DependencyInjection;

using DAL.Repositories.Abstracts;
using DAL.UnitsOfWork.Abstracts;
using DAL.Repositories;
using DAL.UnitsOfWork;

namespace DAL
{
    public static class Data
    {
        public static IServiceCollection SetRepositories(this IServiceCollection services)
        {
            services.AddScoped<Context>();
            services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IClientsRepository, ClientsRepository>();
            services.AddScoped<IGenresRepository, GenresRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
