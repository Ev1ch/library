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
            config.CreateMap<Book, BLL.Models.Book>();
            config.CreateMap<BLL.Models.Book, Book>();
            config.CreateMap<Genre, BLL.Models.Genre>();
            config.CreateMap<BLL.Models.Genre, Genre>();
            config.CreateMap<Author, BLL.Models.Author>();
            config.CreateMap<BLL.Models.Author, Author>();
            config.CreateMap<Form, BLL.Models.Form>();
            config.CreateMap<BLL.Models.Form, Form>();
            config.CreateMap<Client, BLL.Models.Client>();
            config.CreateMap<BLL.Models.Client, Client>();
        }
    }
}
