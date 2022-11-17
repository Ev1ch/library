using PL.Controllers.Abstracts;
using PL.Views.Main;

namespace PL.Controllers
{
    public class MainController : Controller, IController
    {
        private readonly BooksController booksController;

        private readonly ClientsController clientsController;

        public MainController(BooksController booksController, ClientsController clientsController)
        {
            this.booksController = booksController;
            this.clientsController = clientsController;
        }

        public void Init()
        {
            Show();
        }

        public void Show()
        {
            bool shouldExit = false;

            while (!shouldExit)
            {
                new MenuView().Show();

                string command = GetCommand();

                switch (command)
                {
                    case "1":
                        booksController.Init();
                        break;
                    case "2":
                        clientsController.Init();
                        break;
                    default:
                        shouldExit = true;
                        break;
                }
            }
        }
    }
}