using BAL.Mappers;
using BAL.Services.Abstracts;
using DAL.Models;
using DAL.UnitsOfWork.Abstracts;

namespace BAL.Services
{
    internal class ClientsService: Service, IClientsService<int>
    {
        public ClientsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Add(Client<int> client)
        {
            unitOfWork.ClientsRepository.Add(client.ToEntity());
        }

        public void Delete(Client<int> client)
        {
            unitOfWork.ClientsRepository.Delete(client.ToEntity());
        }
    }
}
