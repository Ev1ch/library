using Microsoft.Extensions.DependencyInjection;

using DAL.Repositories.Abstracts;
using DAL.UnitsOfWork.Abstracts;
using DAL.Repositories;
using DAL.UnitsOfWork;

namespace DAL
{
    public static class DalDependencies
    {
        public static IServiceCollection SetDalDependencies(this IServiceCollection services)
        {
            services.AddSingleton<Context>();
            services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IClientsRepository, ClientsRepository>();
            services.AddScoped<IGenresRepository, GenresRepository>();
            services.AddScoped<IFormsRepository, FormsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
