using AutoMapper;

using BLL.Services.Abstracts;
using DAL.UnitsOfWork.Abstracts;

namespace BLL.Services
{
    public class AuthorsService: Service, IAuthorsService
    {
        public AuthorsService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
