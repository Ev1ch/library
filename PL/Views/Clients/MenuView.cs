namespace PL.Views.Clients
{
    public class MenuView
    {
        public void Show()
        {
            Console.Write(Get());
        }

        private string Get()
        {
            return "Main > Clients:\n1. Search by identifier\n1. Search by form identifier\n";
        }
    }
}
