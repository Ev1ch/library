using DAL.UnitsOfWork.Abstracts;

namespace BAL.Services
{
    internal class Service
    {
        protected readonly IUnitOfWork unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
