using PL.Models;

namespace PL.Views.Clients
{
    public class ClientMenuView
    {
        public void Show()
        {
            Console.WriteLine(Get());
        }

        private string Get()
        {
            return "Main > Clients > Client:\n1. Add book by identifier\n2. Delete book by identifier\n";
        }
    }
}
