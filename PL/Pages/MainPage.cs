namespace PL.Pages
{
    public class MainPage : Page
    {
        private BooksPage booksPage;

        private ClientsPage clientsPage;

        public MainPage(BooksPage booksPage, ClientsPage clientsPage)
        {
            this.booksPage = booksPage;
            this.clientsPage = clientsPage;
        }

        public void Show()
        {
            PrintMenu();
            string command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    booksPage.Show();
                    break;
                case "2":
                    clientsPage.Show();
                    break;
                default:
                    Console.WriteLine("Wrong command");
                    break;
            }
        }

        private void PrintMenu()
        {
            string[] commands = { "Books", "Clients" };
            Console.WriteLine("Menu:");
            for (int i = 0; i < commands.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i, commands[i]);
            }
        }
    }
}