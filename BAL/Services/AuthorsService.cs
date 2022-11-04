using BAL.Services.Abstracts;
using DAL.UnitsOfWork.Abstracts;

namespace BAL.Services
{
    internal class AuthorsService: Service, IAuthorsService<int>
    {
        public AuthorsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
