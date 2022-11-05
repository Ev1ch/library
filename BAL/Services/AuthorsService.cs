using AutoMapper;

using BAL.Services.Abstracts;
using DAL.UnitsOfWork.Abstracts;
using DAL.Models;

namespace BAL.Services
{
    internal class AuthorsService: Service, IAuthorsService
    {
        private readonly Mapper mapper;

        public AuthorsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            var config = new MapperConfiguration(config => {
                config.CreateMap<Author, DAL.Entities.Author>();
                config.CreateMap<DAL.Entities.Author, Author>();
            });
            mapper = new Mapper(config);
        }
    }
}
