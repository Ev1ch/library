using PL.Models;

namespace PL.Views.Clients
{
    public class ClientView
    {
        private readonly Client client;

        public ClientView(Client client)
        {
            this.client = client;
        }

        public void Show()
        {
            Console.WriteLine(Get());
        }

        private string Get()
        {
            return $"{client.Id} | {client.FirstName}, {client.MiddleName} {client.LastName}";
        }
    }
}
