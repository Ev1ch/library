using AutoMapper;

using BAL.Services.Abstracts;
using DAL.UnitsOfWork.Abstracts;

namespace BAL.Services
{
    public class AuthorsService: Service, IAuthorsService
    {
        public AuthorsService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
