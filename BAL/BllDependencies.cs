using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

using BAL.Services.Abstracts;
using BAL.Services;
using BAL.Models;

namespace BAL
{
    public static class BllDependencies
    {
        public static IServiceCollection SetBllDependencies(this IServiceCollection services)
        {
            services.AddScoped(provider =>
                new MapperConfiguration(Configure).CreateMapper()
            );
            services.AddScoped<IAuthorsService, AuthorsService>();
            services.AddScoped<IBooksService, BooksService>();
            services.AddScoped<IClientsService, ClientsService>();

            return services;
        }

        public static void Configure(IMapperConfigurationExpression config)
        {
            config.CreateMap<Book, DAL.Entities.Book>();
            config.CreateMap<DAL.Entities.Book, Book>();
            config.CreateMap<Genre, DAL.Entities.Genre>();
            config.CreateMap<DAL.Entities.Genre, Genre>();
            config.CreateMap<Author, DAL.Entities.Author>();
            config.CreateMap<DAL.Entities.Author, Author>();
            config.CreateMap<Form, DAL.Entities.Form>();
            config.CreateMap<DAL.Entities.Form, Form>();
            config.CreateMap<Client, DAL.Entities.Client>();
            config.CreateMap<DAL.Entities.Client, Client>();
        }
    }
}