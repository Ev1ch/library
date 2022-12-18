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
            config.CreateMap<Book, BAL.Models.Book>();
            config.CreateMap<BAL.Models.Book, Book>();
            config.CreateMap<Genre, BAL.Models.Genre>();
            config.CreateMap<BAL.Models.Genre, Genre>();
            config.CreateMap<Author, BAL.Models.Author>();
            config.CreateMap<BAL.Models.Author, Author>();
            config.CreateMap<Form, BAL.Models.Form>();
            config.CreateMap<BAL.Models.Form, Form>();
            config.CreateMap<Client, BAL.Models.Client>();
            config.CreateMap<BAL.Models.Client, Client>();
        }
    }
}
