using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

using PL.Models;
using PL.Controllers;

namespace PL
{
    public static class PlDependencies
    {
        public static IServiceCollection SetPlDependencies(this IServiceCollection services)
        {
            services.AddScoped(provider =>
                new MapperConfiguration(Configure).CreateMapper()
            );
            services.AddSingleton<BooksController>();
            services.AddSingleton<ClientsController>();
            services.AddSingleton<MainController>();
            services.AddSingleton<Startup>();

            return services;
        }

        public static void Configure(IMapperConfigurationExpression config)
        {
            config.CreateMap<Book, DAL.Models.Book>();
            config.CreateMap<DAL.Models.Book, Book>();
            config.CreateMap<Genre, DAL.Models.Genre>();
            config.CreateMap<DAL.Models.Genre, Genre>();
            config.CreateMap<Author, DAL.Models.Author>();
            config.CreateMap<DAL.Models.Author, Author>();
            config.CreateMap<Form, DAL.Models.Form>();
            config.CreateMap<DAL.Models.Form, Form>();
            config.CreateMap<Client, DAL.Models.Client>();
            config.CreateMap<DAL.Models.Client, Client>();
        }
    }
}
