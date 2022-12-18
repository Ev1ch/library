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
            config.CreateMap<BAL.Models.Book, Book>();
            config.CreateMap<BAL.Models.Genre, Genre>();
            config.CreateMap<BAL.Models.Author, Author>();
            config.CreateMap<BAL.Models.Client, Client>();
            config.CreateMap<BAL.Models.Form, Form>();
        }
    }
}