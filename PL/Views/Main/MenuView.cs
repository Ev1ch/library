namespace PL.Views.Main
{
    public class MenuView
    {
        public void Show()
        {
            Console.Write(Get());
        }

        private string Get()
        {
            return "Main:\n1. Books\n2. Clients\n";
        }
    }
}
