using AutoMapper;
using DAL.UnitsOfWork.Abstracts;

namespace BLL.Services
{
    public class Service
    {
        protected readonly IUnitOfWork unitOfWork;

        protected IMapper mapper;

        public Service(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            //this.mapper = mapper;
            this.mapper = new Mapper(new MapperConfiguration(BllDependencies.Configure));
        }
    }
}
