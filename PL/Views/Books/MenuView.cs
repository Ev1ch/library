namespace PL.Views.Books
{
    public class MenuView
    {
        public void Show()
        {
            Console.Write(Get());
        }

        private string Get()
        {
            return "Main > Books:\n1. Search by name\n2. Search by author\n3. Search by genre\n";
        }
    }
}
