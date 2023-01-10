using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

using Web.Models;

namespace Web
{
    public static class WebDependencies
    {
        public static IServiceCollection SetWebDependencies(this IServiceCollection services)
        {
            services.AddScoped(provider =>
                new MapperConfiguration(Configure).CreateMapper()
            );

            return services;
        }

        public static void Configure(IMapperConfigurationExpression config)
        {
            config.CreateMap<BLL.Models.Book, Book>();
            config.CreateMap<Book, BLL.Models.Book>();
            config.CreateMap<BLL.Models.Genre, Genre>();
            config.CreateMap<Genre, BLL.Models.Genre>();
            config.CreateMap<BLL.Models.Author, Author>();
            config.CreateMap<Author, BLL.Models.Author>();
            config.CreateMap<BLL.Models.Client, Client>();
            config.CreateMap<Client, BLL.Models.Client>();
            config.CreateMap<BLL.Models.Form, Form>();
            config.CreateMap<Form, BLL.Models.Form>();
        }
    }
}